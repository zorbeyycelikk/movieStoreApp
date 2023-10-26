using AutoMapper;
using FluentAssertions;
using Vk.Data.Context;
using Vk.Data.Uow;
using Vk.Operations.Command;
using Vk.Operations.Cqrs;
using Vk.Schema;
using Vk.UnitTest.TestSetup;

namespace Vk.UnitTest.Operations.Command.DirectorCommandTest;

//CommonTextFixture'nin sağlamış olduğu mapper ve dbcontext'e erişim sağlar
public class DeleteDirectorCommandTest : IClassFixture<CommonTextFixture>
{
    private readonly VkDbContext dbContext;
    private readonly UnitOfWork unitOfWork;
    private readonly IMapper mapper;
    
    public DeleteDirectorCommandTest(CommonTextFixture textFixture)
    {
        dbContext = textFixture.dbContext;
        mapper = textFixture.Mapper;
        unitOfWork = new UnitOfWork(dbContext);
    }
    
    [Theory]
    [InlineData(-10)]
    [InlineData(345)]
    [InlineData(6789)]
    public async void WhenAlreadyExistDirectorNumberIsGivenToDeleteDirector_ResponseMessageError_ShouldBeReturn(int id)
    {
        // arrange( hazırlık)
        // Test aşamasında bir data yaratsın ve bitince silmesi için bunu yarattık
        
        // act(çalıştırma)
        var handler = new DirectorCommandHandler(mapper , unitOfWork);
        var operation = new DeleteDirectorCommand(id);
        var result = await handler.Handle(operation, default);
        
        // assert(dogrulama)
        result.Message.Should().Be("Error");
    }
}