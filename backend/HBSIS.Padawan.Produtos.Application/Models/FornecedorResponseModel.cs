using System;
using System.Collections.Generic;
using System.Text;

namespace HBSIS.Padawan.Produtos.Application.Models
{
    public class FornecedorResponseModel : FornecedorBaseModel
    {
        public int ID { get; set; }
        //public string RazaoSocial { get; set; }
        //public string CNPJ { get; set; }
        //public string NomeFantasia { get; set; }
        //public string Endereco { get; set; }
        //public string TelefoneDeContato { get; set; }
        //public string EmailDeContato { get; set; }
        //public bool Ativo { get; set; }

        public FornecedorResponseModel(int id, string razaoSocial, string cnpj, string nomeFantasia, string endereco, string telefoneDeContato, string emailDeContato, bool ativo)
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
    }
}