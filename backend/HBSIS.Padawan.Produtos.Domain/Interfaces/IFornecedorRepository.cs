using HBSIS.Padawan.Produtos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Padawan.Produtos.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<FornecedorEntity> GetById(int id);
        Task Create(FornecedorEntity fornecedor);
        Task Update(int id, FornecedorEntity fornecedor);
        Task Delete(int id);
    }
}