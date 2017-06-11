using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoneyLake.Api.DataAccess;
using MoneyLake.Api.DataAccess.DTO;

namespace MoneyLake.Api.Services.Impl
{
    internal class PlantService: BaseService, IPlantService
    {
        public PlantService(DataContext dataContext): base(dataContext)
        {
        }
        
        public async Task<IEnumerable<GreenHouse>> GetGreenHousesAsync()
        {
            return await _dataContext
                .GreenHouses
                .ToListAsync();
        }

        public async Task<GreenHouse> GetPlansInGreenHouseAsync(int greenHouseId)
        {
            return await _dataContext
                .GreenHouses
                .FirstAsync(x => x.Id == greenHouseId);
        }
    }
}
