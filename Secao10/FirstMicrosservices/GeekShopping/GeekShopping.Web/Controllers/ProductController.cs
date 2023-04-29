using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductModel> products = await _productService.FindAllProducts();
            return View(products);
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModel product)
        {
            if(ModelState.IsValid){
                var response =  await _productService.CreateProduct(product);
                if(response != null) return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Update(int id){
            ProductModel product = await _productService.FindProductById(id);
            if(product != null) return View(product);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductModel product){
            if(ModelState.IsValid){
                ProductModel response = await _productService.UpdateProduct(product);
                if(response != null) return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Delete(int id){
            ProductModel product = await _productService.FindProductById(id);
            if(product != null) return View(product);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductModel product){
            
            bool response = await _productService.DeleteProductById(product.Id);
            if(response) return RedirectToAction(nameof(Index));
            return View(product);
        }
    }
}