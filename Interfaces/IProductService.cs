using LarekApi.Entityes;
using MikesPaging.AspNetCore.Common.ViewModels;
using System.Collections.Generic;

namespace LarekApi.Interfaces
{
    public interface IProductService
    {
      public Task<Dictionary<string, List<string>>> GetCategories(PagingOptionsModel pagingOptionsModel);
      public Task AddCategory(string categoryName);
      public Task AddProduct(Product product);
    }
}
