
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW.PrimitiveTypes
{

    public interface IRepository
    {
        Task<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity;
        Task<List<TEntity>> List<TEntity>(ISpecification<TEntity> spec = null) where TEntity : BaseEntity;
        Task<TEntity> Add<TEntity>(TEntity entity) where TEntity : BaseEntity;
        Task Update<TEntity>(TEntity entity) where TEntity : BaseEntity;
        Task Delete<TEntity>(TEntity entity) where TEntity : BaseEntity;


    }

    //public interface IRepository : IRepository<int>
    //{
    //    //Task<T> GetById<T>(int id) where T : BaseEntity;
    //    //Task<List<T>> List<T>() where T : BaseEntity;
    //    //Task<T> Add<T>(T entity) where T : BaseEntity;
    //    //Task Update<T>(T entity) where T : BaseEntity;
    //    //Task Delete<T>(T entity) where T : BaseEntity;
    //}
}
