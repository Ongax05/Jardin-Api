using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IGenericString<T> where T : StringBaseEntity
    {
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<(int totalRegisters, IEnumerable<T> registers)> GetAllAsync(int pageIndex, int pageSize);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
        Task<int> HowMany();
    }
}