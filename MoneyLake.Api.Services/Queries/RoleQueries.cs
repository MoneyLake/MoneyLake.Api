using System.Linq;
using MoneyLake.Api.DataAccess.DTO;

namespace MoneyLake.Api.Services.Queries
{
    public static class RoleQueries
    {
        public static Role GetRoleByName(
            this IQueryable<Role> roles, 
            string roleName)
        {
            return roles.First(x => x.Name == roleName);
        }
    }
}
