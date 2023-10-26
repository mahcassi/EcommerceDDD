using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;

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
            var validateName = product.ValidatePropertyString(product.Nome, "Name");
            var validatePrice = product.ValidatePropertyDecimal(product.Valor, "Price");

            if (validateName && validatePrice)
            {
                product.Estado = true;
                await _product.Add(product);
            }
        }

        public async Task UpdateProduct(Product product)
        {
            var validateName = product.ValidatePropertyString(product.Nome, "Name");
            var validatePrice = product.ValidatePropertyDecimal(product.Valor, "Price");

            if (validateName && validatePrice)
            {
                await _product.Update(product);
            }
        }
    }
}
