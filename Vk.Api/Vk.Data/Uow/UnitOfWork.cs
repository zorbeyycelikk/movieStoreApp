using Vk.Data.Context;
using Vk.Data.Domain;
using Vk.Data.Repository;

namespace Vk.Data.Uow;

public class UnitOfWork : IUnitOfWork
{
    private readonly VkDbContext dbContext;

    public UnitOfWork(VkDbContext dbContext)
    {
        this.dbContext = dbContext;

        CustomerRepository = new GenericRepository<Customer>(dbContext);
        ActorRepository = new GenericRepository<Actor>(dbContext);
        DirectorRepository = new GenericRepository<Director>(dbContext);
        GenreRepository = new GenericRepository<Genre>(dbContext);
        MovieRepository = new GenericRepository<Movie>(dbContext);
        OrderRepository = new GenericRepository<Order>(dbContext);
        UserFavoriteMovieGenresRepository = new GenericRepository<UserFavoriteMovieGenres>(dbContext);
    }

    public void Complete(CancellationToken cancellationToken)
    {
        dbContext.SaveChangesAsync(cancellationToken);
    }

    public void CompleteTransaction()
    {
        using (var transaction = dbContext.Database.BeginTransaction())
        {
            try
            {
                dbContext.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                //Log.Error("CompleteTransactionError", ex);
            }
        }
    }
    public IGenericRepository<Customer> CustomerRepository { get; private set; }
    public IGenericRepository<Actor>    ActorRepository { get; private set; }
    public IGenericRepository<Director> DirectorRepository { get; private set; }
    public IGenericRepository<Genre>    GenreRepository { get; private set; }
    public IGenericRepository<Movie>    MovieRepository { get; private set; }
    public IGenericRepository<Order>    OrderRepository { get; private set; }
    public IGenericRepository<UserFavoriteMovieGenres>     UserFavoriteMovieGenresRepository { get; private set; }

}