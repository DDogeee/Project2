using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.ViewModel;

namespace Project2.IServices
{
    public interface IKeyService
    {
        Task<GenericResultModel<KeyResponseViewModel>> GetKeyAsync();
        Task<GenericResultModel<KeyResponseViewModel>> ExtendKeyAsync(KeyResponseViewModel _key);
        Task<GenericResultModel<KeyResponseViewModel>> DeleteKeyAsync(KeyResponseViewModel _key);
        Task<GenericResultModel<KeyResponseViewModel>> GetKeyIdAsync(int id);
    }
}
