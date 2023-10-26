using AutoMapper;
using FluentAssertions;
using Vk.Data.Context;
using Vk.Data.Uow;
using Vk.Operations.Cqrs;
using Vk.Operations.Query;
using Vk.UnitTest.TestSetup;

namespace Vk.UnitTest.Operations.Command.CustomerCommandTest;

//CommonTextFixture'nin sağlamış olduğu mapper ve dbcontext'e erişim sağlar
public class GetCustomerByIdQueryTest : IClassFixture<CommonTextFixture>
{
    private readonly VkDbContext dbContext;
    private readonly IMapper mapper;
    private readonly UnitOfWork unitOfWork;
    
    public GetCustomerByIdQueryTest(CommonTextFixture textFixture)
    {
        dbContext = textFixture.dbContext;
        mapper = textFixture.Mapper;
        unitOfWork = new UnitOfWork(dbContext);
    }
    
    [Theory]
    [InlineData(-10)]
    [InlineData(345)]
    [InlineData(6789)]
    public async  void WhenNonExistentValueIsGivenToGetCustomerById_ResponseMessageError_ShouldBeReturn(int id)
    {
        // arrange( hazırlık)
        
        // act(çalıştırma)
        var command = new CustomerQueryHandler(mapper, unitOfWork);
        var operation = new GetCustomerById(id);
        
        // assert(dogrulama)
        var result = await command.Handle(operation, default);
        result.Message.Should().Be("Error");
    }
}