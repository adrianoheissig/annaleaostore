using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Repository.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity: class
    {
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity GetByID(int id);
        List<TEntity> GetAll();

    }
}
