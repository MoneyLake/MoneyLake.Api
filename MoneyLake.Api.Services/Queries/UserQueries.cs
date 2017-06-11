using System.Linq;
using MoneyLake.Api.DataAccess.DTO;

namespace MoneyLake.Api.Services.Queries
{
    public static class UserQueries
    {
        public static IQueryable<User> FilterByLogin(
            this IQueryable<User> users, 
            string login)
        {
            return users.Where(x => x.Login.Contains(login));
        }
    }
}
