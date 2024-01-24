using LarekApi.Entityes;
using System.Collections.Generic;

namespace LarekApi.Interfaces
{
    public interface IProductService
    {
      public Task<Dictionary<string, List<string>>> GetCategories();
      public Task AddCategory(string categoryName);
      public Task AddProduct(Product product);
    }
}
