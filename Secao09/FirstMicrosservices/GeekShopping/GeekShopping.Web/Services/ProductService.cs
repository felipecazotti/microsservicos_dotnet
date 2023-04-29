using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        private const string basePath = "api/v1/product";

        public ProductService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<ProductModel>> FindAllProducts()
        {
            var response = await _client.GetAsync(basePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(int id)
        {
            var response = await _client.GetAsync($"{basePath}/{id}");
            if(response.IsSuccessStatusCode) return await response.ReadContentAs<ProductModel>();
            throw new Exception("Algo de errado não está certo");
        }
        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            var response = await _client.PostAsJson(basePath, model);
            if(response.IsSuccessStatusCode) return await response.ReadContentAs<ProductModel>();
            throw new Exception("Algo de errado não está certo");
        }

        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            var response = await _client.PutAsJson(basePath, model);
            if(response.IsSuccessStatusCode) return await response.ReadContentAs<ProductModel>();
            throw new Exception("Algo de errado não está certo");
        }

        public async Task<bool> DeleteProductById(int id)
        {
            var response = await _client.GetAsync($"{basePath}/{id}");
            if(response.IsSuccessStatusCode) return await response.ReadContentAs<bool>();
            throw new Exception("Algo de errado não está certo");
        }

        

        
    }
}