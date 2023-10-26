using AutoMapper;
using FluentAssertions;
using Vk.Data.Context;
using Vk.Data.Uow;
using Vk.Operations.Command;
using Vk.Operations.Cqrs;
using Vk.Schema;
using Vk.UnitTest.TestSetup;

namespace Vk.UnitTest.Operations.Command.MovieCommandTest;

//CommonTextFixture'nin sağlamış olduğu mapper ve dbcontext'e erişim sağlar
public class CreateMovieCommandTest : IClassFixture<CommonTextFixture>
{
    private readonly VkDbContext dbContext;
    private readonly UnitOfWork unitOfWork;
    private readonly IMapper mapper;
    
    public CreateMovieCommandTest(CommonTextFixture textFixture)
    {
        dbContext = textFixture.dbContext;
        mapper = textFixture.Mapper;
        unitOfWork = new UnitOfWork(dbContext);
    }
    
    [Fact]
    public async void WhenAlreadyExistMovieNumberIsGivenToCreateMovie_ResponseMessageError_ShouldBeReturn()
    {
        // arrange( hazırlık)
        // Test aşamasında bir data yaratsın ve bitince silmesi için bunu yarattık

        var Movie = new Data.Domain.Movie
        {
            Id = 100,
            MovieNumber = 100,
            MovieName = "Inception",
            MovieYear = 2101,
            Price = 9999,
            GenreId = 2,
            DirectorId = 2,
            InsertUserId = 401,
            InsertDate = DateTime.Now,
            UpdateUserId = 402,
            UpdateDate = DateTime.Now.AddHours(-3),
            IsActive = true
        };
        dbContext.Add(Movie);
        dbContext.SaveChanges();
        
        // act(çalıştırma)
        var handler = new MovieCommandHandler(mapper , unitOfWork);
        MovieCreateRequest mapped = mapper.Map<MovieCreateRequest>(Movie);
        var operation = new CreateMovieCommand(mapped);
        var result = await handler.Handle(operation, default);
        
        // assert(dogrulama)
        result.Message.Should().Be("Error");
    }
}