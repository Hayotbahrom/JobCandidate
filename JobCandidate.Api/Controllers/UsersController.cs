using JobCandidate.Api.Models;
using JobCandidate.Service.DTOs;
using JobCandidate.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IIUserService userService;
        public UsersController(IIUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> AddOrUpdateAsync([FromBody] UserDto dto)
        {
            var response = new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await userService.AddOrUpdateUserAsync(dto)
            };
            return Ok(response);
        }
    }
}
