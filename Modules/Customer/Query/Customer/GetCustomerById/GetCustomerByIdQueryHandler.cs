using CQRSDEMO.Models.APIs;
using CQRSDEMO.Models.Entities;
using CQRSDEMO.Modules.Customer.Query.Customer.GetCustomer;
using CQRSDEMO.Modules.Customer.Services;
using System.Collections.Generic;

namespace CQRSDEMO.Modules.Customer.Query.Customer.GetCustomerById
{

    public class GetCustomerByIdQueryHandler : CQRS.Queries.QueryHandler<GetCustomerByIdQuery, GetCustomerByIdQueryResult, List<GetCustomerByIdQueryResultData>>
    {
        private readonly ICustomerService _customerService;

        public GetCustomerByIdQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }




        protected override async Task<GetCustomerByIdQueryResult> OnExecute(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            GetCustomerByIdQueryResult result = new GetCustomerByIdQueryResult();

            // ดึงข้อมูลลูกค้า
            CustomerModel customer = await _customerService.GetCustomerByIdAsync(query.Id);

            // ตรวจสอบว่าพบลูกค้าหรือไม่
            if (customer == null)
            {
                result.IsSuccess = false;
                result.Total = 0;
                return result;
            }

            // สร้างข้อมูลผลลัพธ์
            GetCustomerByIdQueryResultData getCustomerQueryResultData = new GetCustomerByIdQueryResultData
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                MembershipType = customer.MembershipType,
                IsGoldShop = customer.IsGoldShop,
                IdCardNumber = customer.IdCardNumber,
                CurrentAddress = customer.CurrentAddress,
                DocumentAddress = customer.DocumentAddress,
            };

            // จัดการผลลัพธ์สุดท้าย
            result = new GetCustomerByIdQueryResult
            {
                IsSuccess = true,
                ResultData = getCustomerQueryResultData,
                Total = 1 // เพราะดึงข้อมูลลูกค้าเพียงคนเดียว
            };

            return result;
        }


    }   
}
