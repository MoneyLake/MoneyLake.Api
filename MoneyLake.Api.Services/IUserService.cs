using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyLake.Api.DataAccess.DTO;

namespace MoneyLake.Api.Services
{
    public interface IUserService
    {
        Task<User> ValidateAsync(
            string login, 
            string password);
        
        Task<IEnumerable<User>> GetAllUsersAsync(string login = "");
        Task<User> GetByLoginAsync(string login);
        
        Task PostTimeAsync(
            int operationId, 
            int statusId,
            TimeSpan time);

        Task CreateUserAsync(string login, string password);
    }
}
