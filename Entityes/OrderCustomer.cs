using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LarekApi.Entityes
{
    public class OrderCustomer
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get;set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        [JsonIgnore]
        public int PriceList { get; set; }
        public List<string>? Products { get; set; }
    }
}
