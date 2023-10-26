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

namespace Vk.UnitTest.Operations.Command.GenreCommandTest;

//CommonTextFixture'nin sağlamış olduğu mapper ve dbcontext'e erişim sağlar
public class UpdateGenreCommandTest : IClassFixture<CommonTextFixture>
{
    private readonly VkDbContext dbContext;
    private readonly IMapper mapper;
    private readonly UnitOfWork unitOfWork;
    
    public UpdateGenreCommandTest(CommonTextFixture textFixture)
    {
        dbContext = textFixture.dbContext;
        mapper = textFixture.Mapper;
        unitOfWork = new UnitOfWork(dbContext);
    }
    
    [Theory]
    [InlineData(9999)]
    [InlineData(1000)]
    [InlineData(-5)]
    public async  void WhenNonExistentValueIsGivenToUpdateGenre_ResponseMessageError_ShouldBeReturn(int id)
    {
        // arrange( hazırlık)
        GenreUpdateRequest test = new GenreUpdateRequest();
        
        // act(çalıştırma)
        var command = new GenreCommandHandler(mapper, unitOfWork);
        var operation = new UpdateGenreCommand(test , id);
        
        // assert(dogrulama)
        var result = await command.Handle(operation, default);
        result.Message.Should().Be("Error");
    }
}