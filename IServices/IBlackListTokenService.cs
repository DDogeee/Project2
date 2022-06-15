using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.IServices
{
    public interface IBlackListTokenService
    {
        Task<bool> CheckTokenInBlackListAsync(string token);
    }
}
