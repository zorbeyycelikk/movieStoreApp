using AutoMapper;
using FluentAssertions;
using Vk.Data.Context;
using Vk.Data.Uow;
using Vk.Operations.Command;
using Vk.Operations.Cqrs;
using Vk.Schema;
using Vk.UnitTest.TestSetup;

namespace Vk.UnitTest.Operations.Command.ActorCommandTest;

//CommonTextFixture'nin sağlamış olduğu mapper ve dbcontext'e erişim sağlar
public class CreateActorCommandTest : IClassFixture<CommonTextFixture>
{
    private readonly VkDbContext dbContext;
    private readonly UnitOfWork unitOfWork;
    private readonly IMapper mapper;
    
    public CreateActorCommandTest(CommonTextFixture textFixture)
    {
        dbContext = textFixture.dbContext;
        mapper = textFixture.Mapper;
        unitOfWork = new UnitOfWork(dbContext);
    }
    
    [Fact]
    public async void WhenAlreadyExistActorNumberIsGivenToCreateActor_ResponseMessageError_ShouldBeReturn()
    {
        // arrange( hazırlık)
        // Test aşamasında bir data yaratsın ve bitince silmesi için bunu yarattık

        var Actor = new Data.Domain.Actor
        {
            ActorNumber = 100,
            ActorFirstName = "Liam",
            ActorLastName = "Davis",
        };
        dbContext.Add(Actor);
        dbContext.SaveChanges();
        
        // act(çalıştırma)
        var handler = new ActorCommandHandler(mapper , unitOfWork);
        ActorCreateRequest mapped = mapper.Map<ActorCreateRequest>(Actor);
        var operation = new CreateActorCommand(mapped);
        var result = await handler.Handle(operation, default);
        
        // assert(dogrulama)
        result.Message.Should().Be("Error");
    }
}