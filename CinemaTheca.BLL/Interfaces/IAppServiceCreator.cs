using CinemaTheca.BLL.Services;

namespace CinemaTheca.BLL.Interfaces
{
    public interface IAppServiceCreator
    {
        IAppService CreateAppService(string connection);
    }
}
