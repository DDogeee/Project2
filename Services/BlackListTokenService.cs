using Microsoft.EntityFrameworkCore;
using Project2.IServices;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Services
{
    public class BlackListTokenService : IBlackListTokenService
    {
        private readonly ToolManagementContext _dbContext;
        public BlackListTokenService(ToolManagementContext db)
        {
            _dbContext = db;
        }
        public async Task<bool> CheckTokenInBlackListAsync(string token)
        {
            var isExpiredToken = await _dbContext.ExpiredTokens.FirstOrDefaultAsync(x => x.ExpiredToken1 == token);
            return isExpiredToken != null;
        }
    }
}
