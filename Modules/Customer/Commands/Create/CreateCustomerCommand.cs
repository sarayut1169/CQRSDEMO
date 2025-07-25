﻿using CQRSDEMO.CQRS.Queries;
using CQRSDEMO.CQRS.Validation;
using CQRSDEMO.Models.APIs;
using FluentValidation;
using MediatR;
using static CQRSDEMO.Models.APIs.CustomerModel;
namespace CQRSDEMO.Modules.Customer.Commands.Create
{


    // ตัวอย่าง Query
    public class CreateCustomerCommand : Query<CreateCustomerCommandResult, List<CreateCustomerCommandResultData>>
    {
   
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MembershipType { get; set; }
        public bool IsGoldShop { get; set; }
        public string IdCardNumber { get; set; }
        public string CurrentAddress { get; set; }
        public string DocumentAddress { get; set; }

    
    }





}
