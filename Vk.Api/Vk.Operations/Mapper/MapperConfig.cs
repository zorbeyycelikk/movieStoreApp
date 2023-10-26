using AutoMapper;
using Vk.Data.Domain;
using Vk.Schema;

namespace Vk.Operation.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<CustomerCreateRequest, Customer>();
        CreateMap<CustomerUpdateRequest, Customer>();
        CreateMap<Customer, CustomerResponse>()
            .ForMember(dest => dest.CustomerFullName, opt => opt
                .MapFrom(src => src.CustomerFirstName + " " + src.CustomerLastName));
            
        CreateMap<ActorCreateRequest, Actor>();
        CreateMap<ActorUpdateRequest, Actor>();
        CreateMap<Actor, ActorResponse>();
        
        CreateMap<DirectorCreateRequest, Director>();
        CreateMap<DirectorUpdateRequest, Director>();
        CreateMap<Director, DirectorResponse>();
        
        CreateMap<GenreCreateRequest, Genre>();
        CreateMap<GenreUpdateRequest, Genre>();
        CreateMap<Genre, GenreResponse>();
        
        CreateMap<MovieCreateRequest, Movie>();
        CreateMap<MovieUpdateRequest, Movie>();
        CreateMap<Movie, MovieResponse>()
            .ForMember(dest => dest.DirectorId, opt => opt.MapFrom(src => src.Director.DirectorNumber))
            .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.Genre.GenreNumber));
        
        CreateMap<UserFavoriteMovieGenresCreateRequest, UserFavoriteMovieGenres>();
        CreateMap<UserFavoriteMovieGenresUpdateRequest, UserFavoriteMovieGenres>();
        CreateMap<UserFavoriteMovieGenres, UserFavoriteMovieGenresResponse>()
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer.Id));

        CreateMap<OrderListRequest, Order>();
        CreateMap<Order, OrderListResponse>()
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer));
        
        CreateMap<OrderCreateRequest, Order>();
        CreateMap<Order, OrderResponse>();
    }
}