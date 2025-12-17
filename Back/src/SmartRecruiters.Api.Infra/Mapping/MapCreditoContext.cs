using Microsoft.EntityFrameworkCore;
using SmartRecruiters.Api.Domain.Entities;
using SmartRecruiters.Api.Infra.Context;

namespace SmartRecruiters.Api.Infra.Mapping
{
    public static class MapCreditoContext
    {
        public static void MapCredito(this DataContext context, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditoEntity>().ToTable("Credito");

            modelBuilder.Entity<CreditoEntity>().HasKey(x => x.Id);

            modelBuilder.Entity<CreditoEntity>()
                .Property(x => x.NumeroCredito)
                .HasColumnName("numero_credito")
                .HasColumnType("varchar(50)")
                .IsUnicode(true)
                .IsRequired();

            modelBuilder.Entity<CreditoEntity>()
                .Property(x => x.DataConstituicao)
                .HasColumnName("data_constituicao")
                .IsRequired();

            modelBuilder.Entity<CreditoEntity>()
                .Property(x => x.NumeroNfse)
                .HasColumnName("numero_nfse")
                .HasColumnType("varchar(50)")
                .IsRequired();

            modelBuilder.Entity<CreditoEntity>()
                .Property(x => x.ValorIssqn)
                .HasColumnName("valor_nfse")
                .HasColumnType("decimal(15,2)")
                .IsRequired();

            modelBuilder.Entity<CreditoEntity>()
                .Property(x => x.TipoCredito)
                .HasColumnName("tipo_credito")
                .HasColumnType("varchar(50)")
                .IsRequired();

            modelBuilder.Entity<CreditoEntity>()
                .Property(x => x.SimplesNacional)
                .HasColumnName("simples_nacional")
                .IsRequired();

            modelBuilder.Entity<CreditoEntity>()
                .Property(x => x.Aliquota)
                .HasColumnName("aliquota")
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            modelBuilder.Entity<CreditoEntity>()
                .Property(x => x.ValorFaturado)
                .HasColumnName("valor_faturado")
                .HasColumnType("decimal(15,2)")
                .IsRequired();

            modelBuilder.Entity<CreditoEntity>()
                .Property(x => x.ValorDeducao)
                .HasColumnName("valor_deducao")
                .HasColumnType("decimal(15,2)")
                .IsRequired();

            modelBuilder.Entity<CreditoEntity>()
                .Property(x => x.BaseCalculo)
                .HasColumnName("base_calculo")
                .HasColumnType("decimal(15,2)")
                .IsRequired();
        }
    }
}