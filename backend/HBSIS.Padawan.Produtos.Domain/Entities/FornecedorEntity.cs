using FluentValidation;
using HBSIS.Padawan.Produtos.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace HBSIS.Padawan.Produtos.Domain.Entities
{
    public class FornecedorEntity : BaseEntity
    {
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }
        public string TelefoneDeContato { get; set; }
        public string EmailDeContato { get; set; }
        public bool Ativo { get; set; }

        public FornecedorEntity()
        {

        }

        public FornecedorEntity(int id, string razaoSocial, string cnpj, string nomeFantasia, string endereco, string telefoneDeContato, string emailDeContato, bool ativo)
        {
            this.ID = id;
            this.RazaoSocial = razaoSocial;
            this.CNPJ = cnpj;
            this.NomeFantasia = nomeFantasia;
            this.Endereco = endereco;
            this.TelefoneDeContato = telefoneDeContato;
            this.EmailDeContato = emailDeContato;
            this.Ativo = ativo;
        }

        public void Update(string razaoSocial, string nomeFantasia, string endereco, string telefoneDeContato, string emailDeContato, bool ativo)
        {
            this.RazaoSocial = razaoSocial;
            this.NomeFantasia = nomeFantasia;
            this.Endereco = endereco;
            this.TelefoneDeContato = telefoneDeContato;
            this.EmailDeContato = emailDeContato;
            this.Ativo = ativo;
        }

        public void Deletar()
        {
            Ativo = false;
        }

        public void Validar()
        {
            var validator = new FornecedorValidator();
            validator.ValidateAndThrow(this);
        }
    }
}