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

namespace Vk.UnitTest.Operations.Command.CustomerCommandTest;

//CommonTextFixture'nin sağlamış olduğu mapper ve dbcontext'e erişim sağlar
public class UpdateCustomerCommandTest : IClassFixture<CommonTextFixture>
{
    private readonly VkDbContext dbContext;
    private readonly IMapper mapper;
    private readonly UnitOfWork unitOfWork;
    
    public UpdateCustomerCommandTest(CommonTextFixture textFixture)
    {
        dbContext = textFixture.dbContext;
        mapper = textFixture.Mapper;
        unitOfWork = new UnitOfWork(dbContext);
    }
    
    [Theory]
    [InlineData(9999)]
    [InlineData(1000)]
    [InlineData(-5)]
    public async  void WhenNonExistentValueIsGivenToUpdateCustomer_ResponseMessageError_ShouldBeReturn(int id)
    {
        // arrange( hazırlık)
        CustomerUpdateRequest test = new CustomerUpdateRequest();
        
        // act(çalıştırma)
        var command = new CustomerCommandHandler(mapper, unitOfWork);
        var operation = new UpdateCustomerCommand(test , id);
        
        // assert(dogrulama)
        var result = await command.Handle(operation, default);
        result.Message.Should().Be("Error");
    }
}