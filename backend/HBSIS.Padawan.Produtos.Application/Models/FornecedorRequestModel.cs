using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HBSIS.Padawan.Produtos.Application.Models
{
    public class FornecedorRequestModel : FornecedorBaseModel
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Razão Social"), Required(ErrorMessage = "A Razão Social deve ser informada.")]
        [StringLength(maximumLength: 100, ErrorMessage = "O nome deve conter no máximo 100 caracteres.")]
        public string RazaoSocial { get; set; }

        [Key]
        [DisplayName("CNPJ"), Required(ErrorMessage = "Preencha o CNPJ.")]
        //[Remote("IsValidCNPJ", "Fornecedores", ErrorMessage = "CNPJ já cadastrado.")]
        [StringLength(maximumLength: 18, ErrorMessage = "O CNPJ deve conter no máximo 18 caracteres.")]
        public string CNPJ { get; set; }

        [DisplayName("Nome Fantasia")]
        [StringLength(maximumLength: 100, ErrorMessage = "Quando informado, o Nome Fantasia deve conter no máximo 18 caracteres.")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "O Endereço deve ser informado.")]
        public string Endereco { get; set; }

        [DisplayName("Telefone de Contato"), Required(ErrorMessage = "O Telefone de Contato deve ser informado.")]
        [RegularExpression(@"\([0-9]{2}\) 9?[0-9]{4}-[0-9]{4}", ErrorMessage = "Digite um telefone válido.")]
        public string TelefoneDeContato { get; set; }

        [Key]
        [DisplayName("Email de Contato"), Required(ErrorMessage = "O Email de Contato deve ser informado.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Digite um email válido.")]
        public string EmailDeContato { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}