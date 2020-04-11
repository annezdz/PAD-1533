using HBSIS.Padawan.Produtos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HBSIS.Padawan.Produtos.Infra.Mappings
{
    public class FornecedorMapConfig : IEntityTypeConfiguration<FornecedorEntity>
    {
        public void Configure(EntityTypeBuilder<FornecedorEntity> builder)
        {
            builder.ToTable("FORNECEDORES");

            builder.Property(f => f.RazaoSocial).HasColumnName(nameof(FornecedorEntity.RazaoSocial)).IsRequired().HasMaxLength(100);
            builder.HasIndex(f => f.RazaoSocial).IsUnique();

            builder.Property(f => f.CNPJ).HasColumnName(nameof(FornecedorEntity.CNPJ)).IsRequired().HasMaxLength(18);
            builder.HasIndex(f => f.CNPJ).IsUnique();

            builder.Property(f => f.NomeFantasia).HasColumnName(nameof(FornecedorEntity.NomeFantasia)).HasMaxLength(100);

            builder.Property(f => f.Endereco).HasColumnName(nameof(FornecedorEntity.Endereco)).IsRequired();

            builder.Property(f => f.TelefoneDeContato).HasColumnName(nameof(FornecedorEntity.TelefoneDeContato)).IsRequired();

            builder.Property(f => f.EmailDeContato).HasColumnName(nameof(FornecedorEntity.EmailDeContato)).IsRequired();
            builder.HasIndex(f => f.EmailDeContato).IsUnique();

            builder.Property(f => f.Ativo).HasColumnName(nameof(FornecedorEntity.Ativo)).IsRequired();
        }
    }
}