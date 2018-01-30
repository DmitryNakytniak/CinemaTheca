using CinemaTheca.DAL.Entities;
using System;

namespace CinemaTheca.DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}
