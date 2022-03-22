using devices.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace devices_back.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        private readonly ILogger<DevicesController> _logger;

        public DevicesController(ILogger<DevicesController> logger, IDeviceService deviceService)
        {
            _logger = logger;
            _deviceService = deviceService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _deviceService.GetAllDevices();

            if (result is null)
                return BadRequest();

            return Ok(_deviceService.GetAllDevices());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("DeviceId is incorrect");

            return Ok(_deviceService.GetDeviceById(id));
        }
    }
}
