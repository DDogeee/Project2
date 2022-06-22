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
                    CreatedBy = s.CreatedBy,
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

        public async Task<GenericResultModel<KeyResponseViewModel>> GenerateKeyAsync(KeyResponseViewModel _key)
        {
            try
            {
                var currentTime = DateTime.Now;
                var key = new Key
                {
                    //A new random key is generated?
                    ToolKey = Guid.NewGuid().ToString().ToUpper(),
                    MachineId = _key.MachineId,                         //How to get this?
                    ToolId = _key.ToolId,
                    Status = 1,                                         //Key is active?
                    // CreatedBy = ?,
                    CreatedDate = currentTime,
                    StartDate = currentTime,
                    ToDate = currentTime.Add(new TimeSpan(365,0,0,0))   //Key expires after 365 days
                };
                _dbContext.Keys.Add(key);
                await _dbContext.SaveChangesAsync();

                return GenericResultModel<KeyResponseViewModel>.Success("Key generated successfully");
            }
            catch
            {   
                return GenericResultModel<KeyResponseViewModel>.Failed("Failed to generate a new key");
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
                _dbContext.Entry(key).State = EntityState.Deleted;
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
                var key = await _dbContext.Keys.FirstOrDefaultAsync(x => x.Id == _key.Id);
                var keyView = new KeyResponseViewModel {
                    ToolKey = key.ToolKey,
                    MachineId = key.MachineId,
                    ToolId = key.ToolId,
                    Status = key.Status,
                    CreatedBy = key.CreatedBy,
                    CreatedDate = key.CreatedDate,
                    StartDate = key.StartDate,
                    ToDate = key.ToDate 
                };
                return GenericResultModel<KeyResponseViewModel>.Success(keyView);
            }
            catch
            {   
                return GenericResultModel<KeyResponseViewModel>.Failed("Failed to get key by ID");
            }
        }
    }
}
