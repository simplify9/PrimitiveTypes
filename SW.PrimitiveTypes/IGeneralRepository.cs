
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SW.Pmm.Primitives
{
    public interface IGeneralRepository
    {
        Task<T> GetById<T>(int id) where T : BaseEntity;
        Task<List<T>> List<T>() where T : BaseEntity;
        Task<T> Add<T>(T entity) where T : BaseEntity;
        Task Update<T>(T entity) where T : BaseEntity;
        Task Delete<T>(T entity) where T : BaseEntity;
    }
}
