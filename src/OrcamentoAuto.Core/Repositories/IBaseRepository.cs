using OrcamentoAuto.Core.Response;

namespace OrcamentoAuto.Core.Repositories;
public interface IBaseRepository<T> where T : class
{
    Task<PagedResponse<T>> GetAllAsync(int pageNumber, int pageSize);
    Task<T> GetByIdAsync(string id);
    Task<T> CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(string id);
}
