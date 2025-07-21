using System.ComponentModel.DataAnnotations.Schema;

namespace CQRSDEMO.Models.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("customer", Schema = "wpftest")]
    public class Customer
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("phone")]
        public string? Phone { get; set; }

        [Column("membership_type")]
        public string? MembershipType { get; set; }

        [Column("is_gold_shop")]
        public bool? IsGoldShop { get; set; }

        [Column("id_card_number")]
        public string? IdCardNumber { get; set; }

        [Column("address")]
        public string? Address { get; set; }

        [Column("current_address")]
        public string? CurrentAddress { get; set; }

        [Column("document_address")]
        public string? DocumentAddress { get; set; }
    }
}
