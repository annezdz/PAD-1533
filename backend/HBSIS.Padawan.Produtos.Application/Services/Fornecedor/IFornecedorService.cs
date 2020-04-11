using HBSIS.Padawan.Produtos.Application.Models;
using HBSIS.Padawan.Produtos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Padawan.Produtos.Application.Services.Fornecedor
{
    public interface IFornecedorService
    {
        Task<FornecedorResponseModel> GetById(int id);
        Task<FornecedorResponseModel> Create(FornecedorRequestModel fornecedorRequestModel);
        Task<FornecedorResponseModel> Update(int id, FornecedorRequestModel fornecedorRequestModel);
        Task Delete(int id);
    }
}