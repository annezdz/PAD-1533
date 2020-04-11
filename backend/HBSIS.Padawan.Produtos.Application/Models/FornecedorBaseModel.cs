using System;
using System.Collections.Generic;
using System.Text;

namespace HBSIS.Padawan.Produtos.Application.Models
{
    public class FornecedorBaseModel
    {
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }
        public string TelefoneDeContato { get; set; }
        public string EmailDeContato { get; set; }
        public bool Ativo { get; set; }
    }
}
