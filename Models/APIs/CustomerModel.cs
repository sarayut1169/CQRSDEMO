namespace CQRSDEMO.Models.APIs
{
    public class CustomerModel : CQRSDEMO.Models.Entities.Customer
    {
        public class CreateCustomerQuery
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


}
