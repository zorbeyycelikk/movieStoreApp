using AutoMapper;
using FluentAssertions;
using Vk.Data.Context;
using Vk.Data.Uow;
using Vk.Operations.Command;
using Vk.Operations.Cqrs;
using Vk.Schema;
using Vk.UnitTest.TestSetup;

namespace Vk.UnitTest.Operations.Command.GenreCommandTest;

//CommonTextFixture'nin sağlamış olduğu mapper ve dbcontext'e erişim sağlar
public class CreateGenreCommandTest : IClassFixture<CommonTextFixture>
{
    private readonly VkDbContext dbContext;
    private readonly UnitOfWork unitOfWork;
    private readonly IMapper mapper;
    
    public CreateGenreCommandTest(CommonTextFixture textFixture)
    {
        dbContext = textFixture.dbContext;
        mapper = textFixture.Mapper;
        unitOfWork = new UnitOfWork(dbContext);
    }
    
    [Fact]
    public async void WhenAlreadyExistGenreNumberIsGivenToCreateGenre_ResponseMessageError_ShouldBeReturn()
    {
        // arrange( hazırlık)
        // Test aşamasında bir data yaratsın ve bitince silmesi için bunu yarattık

        var Genre = new Data.Domain.Genre
        {
            GenreNumber = 100,
            GenreName = "Action"
        };
        dbContext.Add(Genre);
        dbContext.SaveChanges();
        
        // act(çalıştırma)
        var handler = new GenreCommandHandler(mapper , unitOfWork);
        GenreCreateRequest mapped = mapper.Map<GenreCreateRequest>(Genre);
        var operation = new CreateGenreCommand(mapped);
        var result = await handler.Handle(operation, default);
        
        // assert(dogrulama)
        result.Message.Should().Be("Error");
    }
}