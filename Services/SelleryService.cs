using Azure.Core;
using LarekApi.Entityes;
using LarekApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using MikesPaging.AspNetCore;
using MikesPaging.AspNetCore.Common.ViewModels;
using MikesPaging.AspNetCore.Services.Interfaces;
using Serilog;

namespace LarekApi.Services
{
    public class SelleryService : IProductService
    {
        private readonly ApplicationDb _context;
       
        public SelleryService(ApplicationDb context )
        {
            _context = context;
           
        }          
    
        public async Task<Dictionary<string, List<string>>>  GetCategories(PagingOptionsModel pagingOptionsModel)
        {
            var categoriesWithProducts = await _context.Categories
            .Include(c => c.Products)
            .ToListAsync(); // Загрузка всех категорий с продуктами из базы данных

            var paginatedResult = categoriesWithProducts
                .Skip(pagingOptionsModel.PageIndex * pagingOptionsModel.PageSize)
                .Take(pagingOptionsModel.PageSize)
                .ToDictionary(
                    c => c.Name, // Название категории в качестве ключа
                    c => c.Products.Select(p => p.Name).ToList() // Список названий продуктов в категории
                );
            return paginatedResult;
        }

        public async Task AddCategory(string categoryName)
        {
            if (categoryName == null)
            {
                throw new Exception();
            }
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);

            // Если категория не найдена, создаем новую
            if (existingCategory == null)
            {
                var newCategory = new Category
                {
                    Name = categoryName,
                    Products = new List<Product>() // Создаем пустой список продуктов
                };

                // Добавляем новую категорию в контекст
                _context.Categories.Add(newCategory);
                await _context.SaveChangesAsync();

            }
        }
        public async Task AddProduct(Product product)
        {
            var existProduct = _context.Products.FirstOrDefault(x => x.Name == product.Name);
            if (existProduct != null)
            {
                throw new Exception();
            }

            var existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Name == product.Category.Name);
            // Если категория не найдена, создаем новую
            if (existingCategory == null)
            {
                throw new Exception();
            }
            var newProductEntity = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = existingCategory.Id, // Устанавливаем Id существующей категории
            };
            _context.Products.Add(newProductEntity);
            await _context.SaveChangesAsync();

        }
    }
}
