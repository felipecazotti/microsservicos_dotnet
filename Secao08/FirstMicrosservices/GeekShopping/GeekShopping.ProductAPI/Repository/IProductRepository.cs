using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekShopping.ProductAPI.DTO;

namespace GeekShopping.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductDTO>> FindAll();
        Task<ProductDTO> FindById(int id);
        Task<ProductDTO> Create(ProductDTO dto);
        Task<ProductDTO> Upadate(ProductDTO dto);
        Task<bool> Delete(int id);
        
    }
}