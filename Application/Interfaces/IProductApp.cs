﻿using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProdutoApp: IGenericApp<Produto>
    {
        Task AddProduto(Produto Produto);
        Task UpdateProduto(Produto Produto);
    }
}
