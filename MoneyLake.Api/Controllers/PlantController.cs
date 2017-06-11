using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyLake.Api.Services;

namespace MoneyLake.Api.Controllers
{
    [Route("api/plants")]
    public class PlantController: Controller
    {
        private readonly IPlantService _plantService;
        
        public PlantController(IPlantService plantService)
        {
            _plantService = plantService;
        }
        
        [HttpGet]
        public async Task<IEnumerable> Get()
        {
            return await _plantService.GetGreenHousesAsync();
        }
    }
}
