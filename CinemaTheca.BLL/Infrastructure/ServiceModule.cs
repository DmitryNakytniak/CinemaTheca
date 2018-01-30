using CinemaTheca.DAL.Interfaces;
using CinemaTheca.DAL.Repositories;
using Ninject.Modules;

namespace CinemaTheca.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<IdentityUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
