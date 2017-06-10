using System.Collections;
using Microsoft.AspNetCore.Mvc;
using MoneyLake.Api.Services;

namespace MoneyLake.Api.Controllers
{
    [Route("api/[controller]")]
    public class PlantController: Controller
    {
        private readonly IPlantService _plantService;
        
        public PlantController(IPlantService plantService)
        {
            _plantService = plantService;
        }
        
        [HttpGet]
        public IEnumerable Get()
        {
            return _plantService.GetGreenHouses();
        }
    }
}
