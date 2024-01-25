namespace LarekApi.Services
{
    public class OrderNumberGenerationService
    {
        private readonly ApplicationDb _context;

        public OrderNumberGenerationService(ApplicationDb context)
        {
            _context = context;
        }

        public string GenerateUniqueOrderId()
        {
            Random random = new Random();
            string orderId = string.Concat(Enumerable.Range(1, 15).Select(_ => random.Next(0, 20).ToString()));

            // Проверяем уникальность orderId в базе данных
            while (_context.Orders.Any(x => x.OrderId == orderId))
            {
                orderId = string.Concat(Enumerable.Range(1, 15).Select(_ => random.Next(0, 20).ToString()));
            }
            return orderId;
        }
    }
}
