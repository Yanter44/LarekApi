using LarekApi.DtoS;
using LarekApi.Entityes;
using LarekApi.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace LarekApi.Services
{
    public class BuyerService : IBuyerService
    {
        private readonly ApplicationDb _context;
        private readonly OrderNumberGenerationService _orderNumberGeneratorService;
        public BuyerService(ApplicationDb context, OrderNumberGenerationService orderNumberGeneratorService)
        {
            _context = context;
            _orderNumberGeneratorService = orderNumberGeneratorService;
        }
        public async Task<string> CancelProduct(string orderId)
        {
            var existzakaz = _context.Orders.FirstOrDefault(x => x.OrderId == orderId);
            if (existzakaz != null)
            {
                _context.Orders.Remove(existzakaz);
                await _context.SaveChangesAsync();
                return $"Your order is canceled";
            }
            return null;
        }


        public async Task<ProductInfoDto> FindProduct(string ProductName)
        {
            var product = _context.Products.FirstOrDefault(x => x.Name == ProductName);
            if (product != null)
            {
                ProductInfoDto productinfo = new ProductInfoDto
                {
                   Name = product.Name,
                   Price = product.Price,
                   Description = product.Description
                };
                return productinfo;
            }
            return null;
        }

        public async Task<string> OrderProduct(OrderDto order)
        {
            List<string> zakazik = new List<string>();
            int allprice = 0;
            foreach(var ord in order.Products)
            {
                var zakaz = _context.Products.FirstOrDefault(p => p.Name == ord.ToString());  
                if(zakaz != null)
                {
                    zakazik.Add(zakaz.Name);
                    allprice += zakaz.Price;
                }
            }
            string orderId = _orderNumberGeneratorService.GenerateUniqueOrderId();       
            OrderCustomer customer = new OrderCustomer()
            {
                CustomerName = order.CustomerName,
                Address = order.Address,
                PhoneNumber = order.PhoneNumber,
                Products = zakazik,
                OrderId = orderId,
                PriceList = allprice
            };       
            await _context.Orders.AddAsync(customer);
            await _context.SaveChangesAsync();
            return $"You made an order, your price list: {allprice} . Your OrderId {orderId}";        
        }
       
       
    }
}
