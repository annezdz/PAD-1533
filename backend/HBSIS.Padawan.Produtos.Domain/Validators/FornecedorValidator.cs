using FluentValidation;
using HBSIS.Padawan.Produtos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HBSIS.Padawan.Produtos.Domain.Validators
{
    public class FornecedorValidator : AbstractValidator<FornecedorEntity>
    {
        public FornecedorValidator()
        {
            List<Error> errors = new List<Error>();
            try
            {
                RuleFor(f => f.RazaoSocial).NotNull().MaximumLength(100).WithMessage("A Razão Social deve ser informada e conter no máximo 100 caracteres.");
                errors.Add(new Error() { FieldName = "RazaoSocial", Message = "Problema com a Razão Social, verifique." });

                RuleFor(f => f.CNPJ.IsValidCNPJ()).NotNull().MaximumLength(14).WithMessage("O CNPJ deve ser informado.");
                errors.Add(new Error() { FieldName = "CNPJ", Message = "Problema com o CNPJ, verifique." });

                RuleFor(f => f.NomeFantasia).MaximumLength(100).WithMessage("Quando informado, o Nome Fantasia deve conter no máximo 100 caracteres.");

                RuleFor(f => f.Endereco).NotNull().WithMessage("O endereço comercial deve ser infomado.");

                RuleFor(f => f.TelefoneDeContato).NotNull().WithMessage("O Telefone deve ser informado.");
                errors.Add(new Error() { FieldName = "TelefoneDeContato", Message = "Problema com o Telefone, verifique." });

                RuleFor(f => f.EmailDeContato.IsValidEmail()).NotNull().WithMessage("O Email deve ser informado.");
                errors.Add(new Error() { FieldName = "EmailDeContato", Message = "Problema com o Email, verifique." });

                RuleFor(f => f.Ativo).NotNull();
            }
            catch (Exception ex)
            {
                if (errors.Count > 0)
                {
                    throw new Exception(ex.Message);
                }
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador.");
            }
        }
    }
}