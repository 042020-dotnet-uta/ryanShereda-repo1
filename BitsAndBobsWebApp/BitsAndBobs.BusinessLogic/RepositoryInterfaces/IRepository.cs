using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

//Repository structures derived from Programming with Mosh video
//https://www.youtube.com/watch?v=rtXpYpZdOzM
namespace BitsAndBobs.BusinessLogic.RepositoryInterfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);

        Task<IEnumerable<TEntity>> GetAll();

        void Add(TEntity entity);
    }
}
