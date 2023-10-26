using AutoMapper;
using FluentAssertions;
using Vk.Data.Context;
using Vk.Data.Uow;
using Vk.Operations.Command;
using Vk.Operations.Cqrs;
using Vk.Schema;
using Vk.UnitTest.TestSetup;

namespace Vk.UnitTest.Operations.Command.UserFavoriteMovieGenresCommandTest;

//CommonTextFixture'nin sağlamış olduğu mapper ve dbcontext'e erişim sağlar
public class CreateUserFavoriteUserFavoriteMovieGenresUserFavoriteUserFavoriteMovieGenresGenresCommandTest : IClassFixture<CommonTextFixture>
{
    private readonly VkDbContext dbContext;
    private readonly UnitOfWork unitOfWork;
    private readonly IMapper mapper;
    
    public CreateUserFavoriteUserFavoriteMovieGenresUserFavoriteUserFavoriteMovieGenresGenresCommandTest(CommonTextFixture textFixture)
    {
        dbContext = textFixture.dbContext;
        mapper = textFixture.Mapper;
        unitOfWork = new UnitOfWork(dbContext);
    }
    
    [Fact]
    public async void WhenAlreadyExistUserFavoriteMovieGenresNumberIsGivenToCreateUserFavoriteMovieGenres_ResponseMessageError_ShouldBeReturn()
    {
        // arrange( hazırlık)
        // Test aşamasında bir data yaratsın ve bitince silmesi için bunu yarattık

        var UserFavoriteMovieGenres = new Data.Domain.UserFavoriteMovieGenres
        {
            Id = 999,
            CustomerId = 5,
            FavoriteGenreId = 2,
            InsertUserId = 517,
            InsertDate = DateTime.Now.AddDays(-45),
            UpdateUserId = 518,
            UpdateDate = DateTime.Now.AddHours(-4),
            IsActive = true
        };
        dbContext.Add(UserFavoriteMovieGenres);
        dbContext.SaveChanges();
        
        // act(çalıştırma)
        var handler = new UserFavoriteMovieGenresCommandHandler(mapper , unitOfWork);
        UserFavoriteMovieGenresCreateRequest mapped = mapper.Map<UserFavoriteMovieGenresCreateRequest>(UserFavoriteMovieGenres);
        var operation = new CreateUserFavoriteMovieGenresCommand(mapped);
        var result = await handler.Handle(operation, default);
        
        // assert(dogrulama)
        result.Message.Should().Be("Error");
    }
}