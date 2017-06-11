using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MoneyLake.Api.DataAccess;
using MoneyLake.Api.DataAccess.DTO;
using MoneyLake.Api.Services.Contants;
using MoneyLake.Api.Services.Queries;

namespace MoneyLake.Api.Services.Impl
{
    public class UserService: BaseService, IUserService
    {
        public UserService(DataContext dataContext) : base(dataContext) {}

        private static string GetHash(string password)
        {
            var crypt = SHA256.Create();
            var hash = string.Empty;
            var crypto = crypt.ComputeHash(
                Encoding.Unicode.GetBytes(password), 0, 
                Encoding.Unicode.GetByteCount(password));
            return crypto.Aggregate(hash, (current, theByte) => current + theByte.ToString("x2"));
        }
        
        public Task<User> ValidateAsync(string login, string password)
        {
            return Task.Run(() => Validate(login, password));
        }
        
        public Task<IEnumerable<User>> GetAllUsersAsync(string login = "")
        {
            return Task.Run(() => GetAllUsers(login));
        }
        
        public Task<User> GetByLoginAsync(string login)
        {
            return Task.Run(() => GetByLogin(login));
        }

        public Task PostTimeAsync(
            int operationId, 
            int statusId,
            TimeSpan time)
        {
            return Task.Run(() => PostTime(operationId, statusId, time));
        }

        public Task CreateUserAsync(string login, string password)
        {
            return Task.Run(() => CreateUser(login, password));
        }

        public void CreateUser(string login, string password, string role = "")
        {
            var userRole = _dataContext.Roles.GetRoleByName(RoleConstants.User);
            
            var user = new User
            {
                Login = login,
                Password = password,
                IsActive = true,
                RegisteredDateTime = DateTime.UtcNow,
                RoleId = userRole.Id
            };

            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
        }

        public User Validate(string login, string password)
        {
            var hash = GetHash(password);

            var user = _dataContext
                .Users
                .FirstOrDefault(x => x.Login == login && x.Password == hash && x.IsActive);

            if (user == null)
            {
                return null;
            }

            user.LastLogin = DateTime.UtcNow;
            
            _dataContext.Users.Update(user);
            _dataContext.SaveChanges();

            return user;
        }

        public IEnumerable<User> GetAllUsers(string login = "")
        {
            var users = string.IsNullOrEmpty(login) 
                ? _dataContext.Users.ToList() 
                : _dataContext.Users
                    .FilterByLogin(login)
                    .ToList();

            return ClearPassword(users);
        }

        public User GetByLogin(string login)
        {
            return _dataContext.Users.FirstOrDefault(x => x.Login == login);
        }

        public void PostTime(
            int operationId, 
            int statusId,
            TimeSpan time)
        {
            var operation = _dataContext.Operations.First(x => x.Id == operationId);
            operation.SpentTime += time;
            operation.StatusId = statusId;

            _dataContext.Update(operation);
        }

        private static IEnumerable<User> ClearPassword(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                user.Password = string.Empty;
            }

            return users;
        }
    }
}
