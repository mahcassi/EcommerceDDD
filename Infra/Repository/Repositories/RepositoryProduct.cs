using Domain.Interfaces.InterfaceProduto;
using Entities.Entities;
using Infra.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Repositories
{
    public class RepositoryProduto : RepositoryGenerics<Produto>, IProduto
    {
    }
}
