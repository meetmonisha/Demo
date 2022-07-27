using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PackagingMicroservice.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackagingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PackagingController : ControllerBase
    {
        private readonly ILogger<PackagingController> _logger;
        private readonly IConfiguration _configuration;
        private PackagingServices _packagingAndDeliveryServices = new PackagingServices();
        public PackagingController(IConfiguration configuration, ILogger<PackagingController> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet("GetPackagingDeliveryCharge")]
        public float GetPackagingDeliveryCharge(string ComponentType, int Count)
        {
            try
            {
                _logger.LogInformation("GetPackagingDeliveryCharge - Getting Packaging and Delivery Charges");
                return _packagingAndDeliveryServices.GetPackagingDeliveryCharge(ComponentType, Count);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error - {ex}");
                throw ex;
            }
        }
    }
}
