using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LarekApi.Entityes
{
    public class OrderCustomer
    {
        [Key]
        [JsonIgnore]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get;set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        [JsonIgnore]
        public int PriceList { get; set; }
        [JsonIgnore]
        public string OrderId { get; set; }
        public List<string>? Products { get; set; }
    }
}
