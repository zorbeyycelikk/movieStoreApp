using System.Linq.Expressions;
using Vk.Base;
using Vk.Base.Model;

namespace Vk.Data.Repository;

public interface IGenericRepository<TEntity> where TEntity : BaseModel
{
    // Create
    void Insert(TEntity entity, CancellationToken cancellationToken);
    
    // List All
    Task<List<TEntity>> GetAll(CancellationToken cancellationToken ,params string[] includes);
    
    // Get By Id
    Task<TEntity> GetById(int id,CancellationToken cancellationToken,params string[] includes);
    
    // Soft Delete
    void Delete(int id);
    
    // Update
    void Update(TEntity entity);

    Task<TEntity> GetByIdAsync(int id,CancellationToken cancellationToken,params string[] includes);
    
    IQueryable<TEntity> GetAsQueryable(params string[] includes);
    IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression, params string[] includes);
}