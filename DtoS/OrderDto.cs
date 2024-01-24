using System.ComponentModel.DataAnnotations;

namespace LarekApi.DtoS
{
    public class OrderDto
    {
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public List<string> Products { get; set; }

    }
}
