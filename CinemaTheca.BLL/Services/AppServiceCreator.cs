using CinemaTheca.BLL.Interfaces;
using CinemaTheca.DAL.Repositories;

namespace CinemaTheca.BLL.Services
{
    public class AppServiceCreator : IAppServiceCreator
    {
        public IAppService CreateAppService(string connection)
        {
            return new AppService(new IdentityUnitOfWork(connection));
        }
    }
}
