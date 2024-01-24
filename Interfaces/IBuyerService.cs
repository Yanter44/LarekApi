using LarekApi.DtoS;
using LarekApi.Entityes;

namespace LarekApi.Interfaces
{
    public interface IBuyerService
    {
   
        public Task<ProductInfoDto> FindProduct(string ProductName);
        public Task<string> OrderProduct(OrderDto order);
        public Task CancelProduct();
    }
}
