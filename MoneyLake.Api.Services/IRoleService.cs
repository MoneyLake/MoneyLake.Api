using MoneyLake.Api.DataAccess.DTO;

namespace MoneyLake.Api.Services
{
    public interface IRoleService
    {
        Role GetRoleByName(string roleName);
    }
}