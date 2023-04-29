using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeekShopping.ProductAPI.Data;
using GeekShopping.ProductAPI.DTO;
using GeekShopping.ProductAPI.Exceptions;
using GeekShopping.ProductAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        private IMapper _mapper;

        public ProductRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> FindById(int id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> Create(ProductDTO dto)
        {
            Product product = _mapper.Map<Product>(dto);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> Upadate(ProductDTO dto)
        {
            Product productExist = await _context.Products.FirstOrDefaultAsync(p => p.Id == dto.Id);
            if(productExist == null) throw new NotFoundException("Produto não encontrado");
            Product product = _mapper.Map<Product>(dto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);
        }


        public async Task<bool> Delete(int id)
        {
           try{
            Product product = await _context.Products.FirstAsync(p => p.Id == id);
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return true;
           }
           catch (Exception){
            return false;
           }
        }
    }
}