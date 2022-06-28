using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2.IServices;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace Project2.Controllers
{
    [Route("api/quan-ly-key")]
    [ApiController]
    public class KeyController : ControllerBase
    {
        private readonly IKeyService _KeyService;
        public KeyController(IKeyService KeyService)
        {
            _KeyService = KeyService;
        }

        [HttpGet("danh-sach-key")]
        [Authorize]
        public async Task<GenericResultModel<KeyResponseViewModel>> GetKeyAsync()
        {
            return await _KeyService.GetKeyAsync();
        }

        //  No longer generate keys through API directly, but through approving pending orders
        // [HttpPost("sinh-key")]
        // [Authorize]
        // public async Task<GenericResultModel<KeyResponseViewModel>> GenerateKeyAsync(KeyResponseViewModel _key)
        // {
        //     return await _KeyService.GenerateKeyAsync(_key);
        // }

        [HttpPut("gia-han-key")]
        [Authorize]
        public async Task<GenericResultModel<KeyResponseViewModel>> ExtendKeyAsync(KeyResponseViewModel _key)
        {
            return await _KeyService.ExtendKeyAsync(_key);
        }

        [HttpDelete("xoa-key")]
        [Authorize]
        public async Task<GenericResultModel<KeyResponseViewModel>> DeleteKeyAsync(KeyResponseViewModel _key)
        {
            return await _KeyService.DeleteKeyAsync(_key);
        }

        [HttpGet("theo-id")]
        [Authorize]
        public async Task<GenericResultModel<KeyResponseViewModel>> GetKeyIdAsync(KeyResponseViewModel _key)
        {
            return await _KeyService.GetKeyIdAsync(_key);
        }
    }
}
