using SmartRecruiters.Api.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace SmartRecruiters.Api.Domain.Entities
{
    public class CreditoEntity : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string NumeroCredito { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string NumeroNfse { get; set; } = string.Empty;

        [Required]
        public DateTime DataConstituicao { get; set; }

        [Required]
        public decimal ValorIssqn { get; set; } = decimal.Zero;

        [Required]
        [MaxLength(50)]
        public string TipoCredito { get; set; } = EnumTipoCredito.Outros.ToString();

        [Required]
        public bool SimplesNacional { get; set; } = false;

        [Required]
        public decimal Aliquota { get; set; } = decimal.Zero;

        [Required]
        public decimal ValorFaturado { get; set; } = decimal.Zero;

        [Required]
        public decimal ValorDeducao { get; set; } = decimal.Zero;

        [Required]
        public decimal BaseCalculo { get; set; } = decimal.Zero;
    }
}