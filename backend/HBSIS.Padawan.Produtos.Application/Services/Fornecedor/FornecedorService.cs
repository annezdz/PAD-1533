using HBSIS.Padawan.Produtos.Application.Models;
using HBSIS.Padawan.Produtos.Application.Services.Fornecedor;
using HBSIS.Padawan.Produtos.Domain.Entities;
using HBSIS.Padawan.Produtos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Padawan.Produtos.Application.Services.Fornecedor
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        //List<Error> errors = new List<Error>();

        public async Task<FornecedorResponseModel> GetById(int id)
        {
            try
            {
                var fornecedor = await _fornecedorRepository.GetById(id);
                if (fornecedor == null) throw new Exception("Fornecedor não encontrado.");

                return new FornecedorResponseModel(fornecedor.ID, fornecedor.RazaoSocial, fornecedor.CNPJ,
                                                   fornecedor.NomeFantasia, fornecedor.Endereco, fornecedor.TelefoneDeContato,
                                                   fornecedor.EmailDeContato, fornecedor.Ativo);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados.");
            }
        }

        public async Task<FornecedorResponseModel> Create(FornecedorRequestModel fornecedorRequestModel)
        {
            try
            {
                var fornecedor = new FornecedorEntity(fornecedorRequestModel.ID, fornecedorRequestModel.RazaoSocial, fornecedorRequestModel.CNPJ,
                                                      fornecedorRequestModel.NomeFantasia, fornecedorRequestModel.Endereco,
                                                      fornecedorRequestModel.TelefoneDeContato, fornecedorRequestModel.EmailDeContato,
                                                      fornecedorRequestModel.Ativo);
                await _fornecedorRepository.Create(fornecedor);

                return new FornecedorResponseModel(fornecedor.ID, fornecedor.RazaoSocial, fornecedor.CNPJ, fornecedor.NomeFantasia, fornecedor.Endereco, fornecedor.TelefoneDeContato, fornecedor.EmailDeContato, fornecedor.Ativo);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados.");
            }
        }

        public async Task<FornecedorResponseModel> Update(int id, FornecedorRequestModel fornecedorRequestModel)
        {
            try
            {
                var fornecedor = await _fornecedorRepository.GetById(id);
                if (fornecedor == null) throw new ArgumentException("Fornecedor não encontrado.");
                fornecedor.Update(fornecedorRequestModel.RazaoSocial, fornecedorRequestModel.NomeFantasia,
                                      fornecedorRequestModel.Endereco, fornecedorRequestModel.TelefoneDeContato,
                                      fornecedorRequestModel.EmailDeContato, fornecedorRequestModel.Ativo);

                return new FornecedorResponseModel(fornecedor.ID, fornecedor.RazaoSocial, fornecedor.CNPJ, fornecedor.NomeFantasia, fornecedor.Endereco, fornecedor.TelefoneDeContato, fornecedor.EmailDeContato, fornecedor.Ativo);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados.");
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var fornecedor = await _fornecedorRepository.GetById(id);
                if (fornecedor == null) throw new ArgumentException("Fornecedor não encontrado.");
                await _fornecedorRepository.Delete(id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados.");
            }
        }
    }
}