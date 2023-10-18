using Application.Interfaces;
using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OpenApp
{
    public class AppProduct : IProductApp
    {
        private readonly IProduct _product;

        private readonly IServiceProduct _serviceProduct;
        public AppProduct(IProduct product, IServiceProduct serviceProduct)
        {
            _product = product;
            _serviceProduct = serviceProduct;
        }
        public async Task AddProduct(Product product)
        {
            await _serviceProduct.AddProduct(product);
        }

        public async Task UpdateProduct(Product product)
        {
            await _serviceProduct.UpdateProduct(product);
        }

        public async Task Add(Product Object)
        {
            await _product.Add(Object);
        }

        public async Task Delete(Product Object)
        {
            await _product.Delete(Object);
        }

        public async Task<Product> GetEntityById(int Id)
        {
            return await _product.GetEntityById(Id);
        }

        public async Task<List<Product>> List()
        {
           return await _product.List();
        }

        public async Task Update(Product Object)
        {
            await _product.Update(Object); ;
        }
        
    }
}
