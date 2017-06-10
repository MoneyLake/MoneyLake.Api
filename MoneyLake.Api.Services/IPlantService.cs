using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyLake.Api.DataAccess.DTO;

namespace MoneyLake.Api.Services
{
    public interface IPlantService
    {
        Task<IEnumerable<GreenHouse>> GetGreenHousesAsync();

        Task<GreenHouse> GetPlansInGreenHouseAsync(int greenHouseId);
    }
}
