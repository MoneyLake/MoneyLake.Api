using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyLake.Api.DataAccess.DTO;
using MoneyLake.Api.Responses;
using MoneyLake.Api.Services;

namespace MoneyLake.Api.Controllers
{
    [Route("api/users")]
    public class UserController: Controller
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("login")]
        public async Task<BaseResponse> Login(string login, string password)
        {
            return await _userService.ValidateAsync(login, password) != null
                ? BaseResponse.Success() 
                : BaseResponse.Failure();
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userService.GetAllUsersAsync();
        }
        
        [HttpGet("{login}")]
        public async Task<User> GetByLogin(string login)
        {
            return await _userService.GetByLoginAsync(login);
        }
    }
}
