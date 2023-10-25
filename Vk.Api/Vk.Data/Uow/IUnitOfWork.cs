using Vk.Data.Domain;
using Vk.Data.Repository;

namespace Vk.Data.Uow;

public interface IUnitOfWork
{
    void Complete(CancellationToken cancellationToken);
    void CompleteTransaction();

    public IGenericRepository<Customer> CustomerRepository { get; }
    public IGenericRepository<Actor> ActorRepository { get; }
    public IGenericRepository<Director> DirectorRepository { get; }
    public IGenericRepository<Genre> GenreRepository { get; }
    public IGenericRepository<Movie> MovieRepository { get; }
    public IGenericRepository<Order> OrderRepository { get; }
    
}