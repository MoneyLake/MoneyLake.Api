using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoneyLake.Api.DataAccess;
using MoneyLake.Api.DataAccess.DTO;

namespace MoneyLake.Api.Services.Impl
{
    internal class PlantService: IPlantService
    {
        private readonly DataContext _dataContext;
        
        public PlantService(DataContext dataContext)
        {
            _dataContext = dataContext;
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
