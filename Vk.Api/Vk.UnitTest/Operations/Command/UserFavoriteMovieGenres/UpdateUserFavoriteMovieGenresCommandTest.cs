using AutoMapper;
using FluentAssertions;
using Vk.Data.Context;
using Vk.Data.Uow;
using Vk.Operation.Command;
using Vk.Operation.Cqrs;
using Vk.Operations.Command;
using Vk.Operations.Cqrs;
using Vk.Schema;
using Vk.UnitTest.TestSetup;

namespace Vk.UnitTest.Operations.Command.UserFavoriteMovieGenresCommandTest;

//CommonTextFixture'nin sağlamış olduğu mapper ve dbcontext'e erişim sağlar
public class UpdateUserFavoriteUserFavoriteMovieGenresGenresCommandTest : IClassFixture<CommonTextFixture>
{
    private readonly VkDbContext dbContext;
    private readonly IMapper mapper;
    private readonly UnitOfWork unitOfWork;
    
    public UpdateUserFavoriteUserFavoriteMovieGenresGenresCommandTest(CommonTextFixture textFixture)
    {
        dbContext = textFixture.dbContext;
        mapper = textFixture.Mapper;
        unitOfWork = new UnitOfWork(dbContext);
    }
    
    [Theory]
    [InlineData(9999)]
    [InlineData(1000)]
    [InlineData(-5)]
    public async  void WhenNonExistentValueIsGivenToUpdateUserFavoriteMovieGenres_ResponseMessageError_ShouldBeReturn(int id)
    {
        // arrange( hazırlık)
        UserFavoriteMovieGenresUpdateRequest test = new UserFavoriteMovieGenresUpdateRequest();
        
        // act(çalıştırma)
        var command = new UserFavoriteMovieGenresCommandHandler(mapper, unitOfWork);
        var operation = new UpdateUserFavoriteMovieGenresCommand(test , id);
        
        // assert(dogrulama)
        var result = await command.Handle(operation, default);
        result.Message.Should().Be("Error");
    }
}