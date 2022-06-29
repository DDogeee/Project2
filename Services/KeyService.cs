using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project2.IServices;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.ViewModel;


namespace Project2.Services
{
    public class KeyService : IKeyService
    {
        private readonly ToolManagementContext _dbContext;
        public KeyService(ToolManagementContext db)
        {
            _dbContext = db;
        }

        public async Task<GenericResultModel<KeyResponseViewModel>> GetKeyAsync()
        {
            try
            {
                var keys = await _dbContext.Keys.Select(s => new KeyResponseViewModel
                {
                    Id = s.Id,
                    MachineId = s.MachineId,
                    ToolId = s.ToolId,
                    ToolKey = s.ToolKey,
                    Status = s.Status,
                    CreatedDate = s.CreatedDate,
                    StartDate = s.StartDate,
                    ToDate = s.ToDate
                }).ToListAsync();

                return GenericResultModel<KeyResponseViewModel>.Success(keys);
            }
            catch
            {   
                return GenericResultModel<KeyResponseViewModel>.Failed("Failed to view list of keys");
            }

        }
        public async Task<GenericResultModel<KeyResponseViewModel>> ExtendKeyAsync(KeyResponseViewModel _key)
        {
            try
            {
                var currentTime = DateTime.Now;
                var key = await _dbContext.Keys.FirstOrDefaultAsync(x => x.Id == _key.Id);
                key.StartDate = currentTime;
                key.ToDate = currentTime.Add(new TimeSpan(365,0,0,0));   //Key is extended for another 365 days? -> Other extension methods?
                _dbContext.Entry(key).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return GenericResultModel<KeyResponseViewModel>.Success("Key extended successfully");
            }
            catch
            {   
                return GenericResultModel<KeyResponseViewModel>.Failed("Failed to extend key");
            }
        }
        public async Task<GenericResultModel<KeyResponseViewModel>> DeleteKeyAsync(KeyResponseViewModel _key)
        {
            try
            {
                var key = await _dbContext.Keys.FirstOrDefaultAsync(x => x.Id == _key.Id);
                key.Status = Constants.StatusDeleted;
                _dbContext.Entry(key).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return GenericResultModel<KeyResponseViewModel>.Success("Key deleted successfully");
            }
            catch
            {   
                return GenericResultModel<KeyResponseViewModel>.Failed("Failed to delete key");
            }
        }
        public async Task<GenericResultModel<KeyResponseViewModel>> GetKeyIdAsync(KeyResponseViewModel _key)
        {
            try
            {
                var s = await _dbContext.Keys.FirstOrDefaultAsync(x => x.Id == _key.Id);
                var keyView = new KeyResponseViewModel {
                    Id = s.Id,
                    MachineId = s.MachineId,
                    ToolId = s.ToolId,
                    ToolKey = s.ToolKey,
                    Status = s.Status,
                    CreatedDate = s.CreatedDate,
                    StartDate = s.StartDate,
                    ToDate = s.ToDate
                };
                return GenericResultModel<KeyResponseViewModel>.Success(keyView);
            }
            catch
            {   
                return GenericResultModel<KeyResponseViewModel>.Failed("Failed to get key by ID" + _key.Id);
            }
        }
        public async Task<int> GenerateKey(int _ToolId, string _MachineId)
        {
            try
            {
                var currentTime = DateTime.Now;
                var key = new Key
                {
                    ToolId = _ToolId,
                    MachineId = _MachineId,
                    ToolKey = Guid.NewGuid().ToString().ToUpper(),
                    Status = Constants.StatusPending,                   //Key awaits activation
                    CreatedDate = currentTime,
                };
                _dbContext.Keys.Add(key);
                await _dbContext.SaveChangesAsync();

                Console.WriteLine("Generate key for this order successfully");
                return key.Id;
            }
            catch
            {   
                Console.WriteLine("Failed to generate a new key for this order");
                return 0;
            }
        }

        public async void ActivateKey(Key pendingKey)
        {
            try
            {
                var currentTime = DateTime.Now;

                pendingKey.Status = Constants.StatusActive;
                pendingKey.StartDate = currentTime;
                pendingKey.ToDate = currentTime.Add(new TimeSpan(365,0,0,0));       //Key expires after 365 days
                _dbContext.Entry(pendingKey).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                Console.WriteLine("Activate key {0} successfully", pendingKey.Id);
            }
            catch
            {
                Console.WriteLine("Failed to activate key {0}", pendingKey.Id);
            }
        }
    }
}
