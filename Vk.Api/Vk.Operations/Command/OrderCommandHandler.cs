using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vk.Base.Response;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Operations.Cqrs;
using Vk.Schema;

namespace Vk.Operations.Command;


public class OrderCommandHandler :
    IRequestHandler<CreateOrderCommand, ApiResponse<OrderResponse>>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public OrderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<OrderResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var entity_customer_id = await unitOfWork.CustomerRepository.GetAsQueryable()
            .Where(x => x.CustomerNumber == request.Model.CustomerId).SingleOrDefaultAsync(cancellationToken);
        if (entity_customer_id is null)
        {
            return new ApiResponse<OrderResponse>("Boyle bir kullanici yok");
        }

        var entity_movie = await unitOfWork.MovieRepository.GetAsQueryable()
            .Where(x => x.MovieNumber == request.Model.PurshchaseMovieId).SingleOrDefaultAsync(cancellationToken);
        
        if (entity_customer_id is null)
        {
            return new ApiResponse<OrderResponse>("Boyle bir film yok");
        }
        
        string purschaseNumber = Guid.NewGuid().ToString().Replace("-", "").ToLower();
        
        Order newOrder = new Order();
        newOrder.PurschaseNumber = purschaseNumber;
        newOrder.PurchaserCustomer = entity_customer_id.CustomerFirstName + " " + entity_customer_id.CustomerLastName;
        newOrder.PurchasedMovie = entity_movie.MovieName;
        newOrder.Price = entity_movie.Price;
        newOrder.PurchaseDate = DateTime.UtcNow;
        newOrder.CustomerId = request.Model.CustomerId;
        newOrder.IsActive = true;
        
        unitOfWork.OrderRepository.Insert(newOrder,cancellationToken);
        unitOfWork.Complete(cancellationToken);
        
        var x = mapper.Map<OrderResponse>(newOrder);
        return new ApiResponse<OrderResponse>(x);
    }   
}