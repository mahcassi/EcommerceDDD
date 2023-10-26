using Domain.Interfaces.InterfaceProduto;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;

namespace Domain.Services
{
    public class ServiceProduto : IServiceProduto
    {
        private readonly IProduto _Produto;

        public ServiceProduto(IProduto Produto)
        {
            _Produto = Produto;
        }

        public async Task AddProduto(Produto Produto)
        {
            var validateName = Produto.ValidatePropertyString(Produto.Nome, "Name");
            var validatePrice = Produto.ValidatePropertyDecimal(Produto.Valor, "Price");

            if (validateName && validatePrice)
            {
                Produto.Estado = true;
                await _Produto.Add(Produto);
            }
        }

        public async Task UpdateProduto(Produto Produto)
        {
            var validateName = Produto.ValidatePropertyString(Produto.Nome, "Name");
            var validatePrice = Produto.ValidatePropertyDecimal(Produto.Valor, "Price");

            if (validateName && validatePrice)
            {
                await _Produto.Update(Produto);
            }
        }
    }
}
