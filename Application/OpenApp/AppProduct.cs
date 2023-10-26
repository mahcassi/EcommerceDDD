using Application.Interfaces;
using Domain.Interfaces.InterfaceProduto;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OpenApp
{
    public class AppProduto : IProdutoApp
    {
        private readonly IProduto _Produto;

        private readonly IServiceProduto _serviceProduto;
        public AppProduto(IProduto Produto, IServiceProduto serviceProduto)
        {
            _Produto = Produto;
            _serviceProduto = serviceProduto;
        }
        public async Task AddProduto(Produto Produto)
        {
            await _serviceProduto.AddProduto(Produto);
        }

        public async Task UpdateProduto(Produto Produto)
        {
            await _serviceProduto.UpdateProduto(Produto);
        }

        public async Task Add(Produto Object)
        {
            await _Produto.Add(Object);
        }

        public async Task Delete(Produto Object)
        {
            await _Produto.Delete(Object);
        }

        public async Task<Produto> GetEntityById(int Id)
        {
            return await _Produto.GetEntityById(Id);
        }

        public async Task<List<Produto>> List()
        {
           return await _Produto.List();
        }

        public async Task Update(Produto Object)
        {
            await _Produto.Update(Object); ;
        }
        
    }
}
