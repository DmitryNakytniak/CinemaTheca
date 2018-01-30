using CinemaTheca.DAL.EF;
using CinemaTheca.DAL.Entities;
using CinemaTheca.DAL.Interfaces;

namespace CinemaTheca.DAL.Repositories
{
    public class ClientManager : IClientManager
    {
        public ApplicationContext DataBase { get; set; }
        public ClientManager(ApplicationContext db)
        {
            DataBase = db;
        }

        public void Create(ClientProfile item)
        {
            DataBase.ClientProfiles.Add(item);
            DataBase.SaveChanges();
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
