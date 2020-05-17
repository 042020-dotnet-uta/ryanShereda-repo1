using System;
using System.Collections.Generic;
using System.Text;
using BitsAndBobs.BuildModels;

//Unit of Work details derived from Programming with Mosh video
//https://www.youtube.com/watch?v=rtXpYpZdOzM
namespace BitsAndBobs.BusinessLogic.RepositoryInterfaces
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<Location> Locations { get; }

        int Complete();
    }
}
