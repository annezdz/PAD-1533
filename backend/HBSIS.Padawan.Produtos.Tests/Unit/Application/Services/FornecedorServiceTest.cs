using NUnit.Framework;
using HBSIS.Padawan.Produtos.Application.Services.Fornecedor;
using HBSIS.Padawan.Produtos.Domain.Interfaces;
using NSubstitute;
using HBSIS.Padawan.Produtos.Application.Models;
using System.Threading.Tasks;
using AngleSharp.Dom;
using HBSIS.Padawan.Produtos.Domain.Entities;

namespace HBSIS.Padawan.Produtos.Tests.Unit.Application.Services
{
    [TestFixture]

    public class FornecedorTestService
    {
        private IFornecedorRepository _fornecedorRepository; ;
        private FornecedorService _fornecedorService;
        [SetUp]
        public void LoadContext()
        {
            _fornecedorRepository = Substitute.For<IFornecedorRepository>();
            _fornecedorService = new FornecedorService(_fornecedorRepository);
        }

        [Test]
        public async Task DeveriaCadastrarFornecedor()
        {
            var fornecedor = new FornecedorRequestModel
            {
                RazaoSocial = "Fique Rico LTDA",
                CNPJ = "72428980000139",
                NomeFantasia="Muito Rico",
                Endereco = "Rua dos Milionarios",
                TelefoneDeContato = "(47)3333-3333",
                EmailDeContato = "rico@rico.com.br"
            };

            var resposta = await _fornecedorService.Create(fornecedor);

            await _fornecedorRepository.Received(1).Create(Arg.Is<FornecedorEntity>(f => f.RazaoSocial == "Fique Rico LTDA"
                                                                                     && f.CNPJ == "72428980000139"
                                                                                     && f.NomeFantasia == "Muito Rico"
                                                                                     && f.Endereco == "Rua dos Milionarios"
                                                                                     && f.TelefoneDeContato == "(47)3333-3333"
                                                                                     && f.EmailDeContato == "rico@rico.com.br"));
            
        }

        [Test]

        public async Task DeveriaAtualizarFornecedor()
        {
            var id = 1;
            var fornecedor = new FornecedorRequestModel
            {
                RazaoSocial = "Fique Rico LTDA",
                CNPJ = "72428980000139",
                NomeFantasia = "Muito Rico",
                Endereco = "Rua dos Milionarios",
                TelefoneDeContato = "(47)3333-3333",
                EmailDeContato = "rico@rico.com.br"
            };

            var resposta = await _fornecedorService.Update(id, fornecedor);

            await _fornecedorRepository.Received(1).Update(Arg.Is<int>(f=>f == id), 
                Arg.Is<FornecedorEntity>(f => f.RazaoSocial == "Fique Rico LTDA"
                                            && f.CNPJ == "72428980000139"
                                            && f.NomeFantasia == "Muito Rico"
                                            && f.Endereco == "Rua dos Milionarios"
                                            && f.TelefoneDeContato == "(47)3333-3333"
                                            && f.EmailDeContato == "rico@rico.com.br"));

        }

        public async Task DeveriaBuscarFornecedorPorId()
        {
            var id = 1;
            var fornecedor = new FornecedorRequestModel
            {
                RazaoSocial = "Fique Rico LTDA",
                CNPJ = "72428980000139",
                NomeFantasia = "Muito Rico",
                Endereco = "Rua dos Milionarios",
                TelefoneDeContato = "(47)3333-3333",
                EmailDeContato = "rico@rico.com.br"
            };

            _fornecedorRepository.GetById(id).Returns(fornecedor);
            var resposta = await _fornecedorRepository.GetById(id);


            resposta.Equals()

        }


        public async Task DeveriaExcluirFornecedor()
        {
            var id = 1;
            var fornecedor = new FornecedorRequestModel
            {
                RazaoSocial = "Fique Rico LTDA",
                CNPJ = "72428980000139",
                NomeFantasia = "Muito Rico",
                Endereco = "Rua dos Milionarios",
                TelefoneDeContato = "(47)3333-3333",
                EmailDeContato = "rico@rico.com.br"
            };

            var resposta = await _fornecedorService.Delete(id, fornecedor);

            await _fornecedorRepository.Received(1).Delete(Arg.Is<int>(f => f == id),
                Arg.Is<FornecedorEntity>(f => f.RazaoSocial == "Fique Rico LTDA"
                                            && f.CNPJ == "72428980000139"
                                            && f.NomeFantasia == "Muito Rico"
                                            && f.Endereco == "Rua dos Milionarios"
                                            && f.TelefoneDeContato == "(47)3333-3333"
                                            && f.EmailDeContato == "rico@rico.com.br"));

        }
    }
    }
}


  