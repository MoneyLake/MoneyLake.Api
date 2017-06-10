using System.Collections;

namespace MoneyLake.Api.Services
{
    public interface IPlantService
    {
        IEnumerable GetGreenHouses();

        IEnumerable GetPlansInGreenHouse(int greenHouseId);
    }
}
