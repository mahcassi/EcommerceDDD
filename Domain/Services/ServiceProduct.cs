using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IProduct _product;

        public ServiceProduct(IProduct product)
        {
            _product = product;
        }

        public async Task AddProduct(Product product)
        {
            var validateName = product.ValidatePropertyString(product.Name, "Name");
            var validatePrice = product.ValidatePropertyDecimal(product.Price, "Price");

            if (validateName && validatePrice)
            {
                product.State = true;
                await _product.Add(product);
            }
        }

        public async Task UpdateProduct(Product product)
        {
            var validateName = product.ValidatePropertyString(product.Name, "Name");
            var validatePrice = product.ValidatePropertyDecimal(product.Price, "Price");

            if (validateName && validatePrice)
            {
                await _product.Update(product);
            }
        }
    }
}
