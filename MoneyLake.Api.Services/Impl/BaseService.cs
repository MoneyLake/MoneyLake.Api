using MoneyLake.Api.DataAccess;

namespace MoneyLake.Api.Services.Impl
{
    public class BaseService
    {
        protected readonly DataContext _dataContext;
        
        public BaseService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
