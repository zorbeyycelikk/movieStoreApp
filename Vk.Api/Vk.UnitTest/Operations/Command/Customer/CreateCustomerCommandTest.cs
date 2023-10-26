using AutoMapper;
using FluentAssertions;
using Vk.Data.Context;
using Vk.Data.Uow;
using Vk.Operations.Command;
using Vk.Operations.Cqrs;
using Vk.Schema;
using Vk.UnitTest.TestSetup;

namespace Vk.UnitTest.Operations.Command.CustomerCommandTest;

//CommonTextFixture'nin sağlamış olduğu mapper ve dbcontext'e erişim sağlar
public class CreateCustomerCommandTest : IClassFixture<CommonTextFixture>
{
    private readonly VkDbContext dbContext;
    private readonly UnitOfWork unitOfWork;
    private readonly IMapper mapper;
    
    public CreateCustomerCommandTest(CommonTextFixture textFixture)
    {
        dbContext = textFixture.dbContext;
        mapper = textFixture.Mapper;
        unitOfWork = new UnitOfWork(dbContext);
    }
    
    [Fact]
    public async void WhenAlreadyExistCustomerNumberIsGivenToCreateCustomer_ResponseMessageError_ShouldBeReturn()
    {
        // arrange( hazırlık)
        // Test aşamasında bir data yaratsın ve bitince silmesi için bunu yarattık

        var customer = new Data.Domain.Customer
        {
            CustomerNumber = 100,
            CustomerFirstName = "Liam",
            CustomerLastName = "Davis",
        };
        dbContext.Add(customer);
        dbContext.SaveChanges();
        
        // act(çalıştırma)
        var handler = new CustomerCommandHandler(mapper , unitOfWork);
        CustomerCreateRequest mapped = mapper.Map<CustomerCreateRequest>(customer);
        var operation = new CreateCustomerCommand(mapped);
        var result = await handler.Handle(operation, default);
        
        // assert(dogrulama)
        result.Message.Should().Be("Error");
    }
}