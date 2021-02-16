using APIs.Custom_entities;
using APIs.Responses;
using APIs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        private readonly IServerService _ServerService;
        public ServerController(IServerService serverService)
        {
            _ServerService = serverService;
        }

        [HttpGet]
        public async Task<IActionResult> GetServer() {
            var server =await _ServerService.GetServers();
            return Ok(server);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> GetServerStatus(int id, [FromBody] CustomServer message) {
            var serverStatus = await _ServerService.ChangeServerStatus(id,message);

            var response = new ApiResponse<bool>(serverStatus);

            return Ok(response);

        }
    }
}
