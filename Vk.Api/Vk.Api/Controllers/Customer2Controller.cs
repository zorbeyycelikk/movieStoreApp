// using AutoMapper;
// using Microsoft.AspNetCore.Mvc;
// using Vk.Data.Domain;
// using Vk.Data.Uow;
// using Vk.Schema;
//
// namespace VkApi.Controllers;
// [NonController]
// [Route("vk/api/v1/[controller]")]
// [ApiController]
// public class Customer2Controller : ControllerBase
// {
//     private readonly IUnitOfWork unitOfWork;
//     private readonly IMapper mapper;
//
//     public Customer2Controller(IUnitOfWork unitOfWork,IMapper mapper)
//     {
//         this.unitOfWork = unitOfWork;
//         this.mapper = mapper;
//     }
//     
//     [HttpGet]
//     public async Task<List<CustomerResponse>> Get(CancellationToken cancellationToken)
//     {
//         List<Customer> x =  await unitOfWork.CustomerRepository.GetAll(cancellationToken);
//         List<CustomerResponse> response = mapper.Map<List<CustomerResponse>>(x);
//         return response;
//     }
//
//     [HttpGet("{id}")]
//     public async Task<CustomerResponse> Get(int id , CancellationToken cancellationToken)
//     {
//         Customer x = await unitOfWork.CustomerRepository.GetById(id , cancellationToken);
//         CustomerResponse response = mapper.Map<CustomerResponse>(x);
//         return response;
//     }
//
//     [HttpPost]
//     public CustomerResponse Post([FromBody] CustomerCreateRequest request , CancellationToken  cancellationToken)
//     {
//         Customer x = mapper.Map<Customer>(request);
//         unitOfWork.CustomerRepository.Insert(x,cancellationToken);
//         unitOfWork.Complete();
//         
//         CustomerResponse response = mapper.Map<CustomerResponse>(x);
//         return response;
//     }
//     
//     [HttpPut("{id}")]
//     public async  Task<CustomerResponse> Put(int id, [FromBody] CustomerUpdateRequest request , CancellationToken cancellationToken)
//     {
//         var entity = await unitOfWork.CustomerRepository.GetById(id,cancellationToken);
//         
//         entity.UpdateUserId = 100;
//         entity.UpdateDate = DateTime.Now;
//         entity.CustomerFirstName = request.CustomerFirstName;
//         entity.CustomerLastName = request.CustomerLastName;
//         
//         Customer x = mapper.Map<Customer>(entity);
//         
//         unitOfWork.CustomerRepository.Update(x);
//         unitOfWork.Complete();
//         
//         CustomerResponse response = mapper.Map<CustomerResponse>(x);
//         return response;
//     }
//     
//     [HttpDelete("{id}")]
//     public void Delete(int id)
//     {
//         unitOfWork.CustomerRepository.Delete(id);
//         unitOfWork.Complete();
//     }
// }