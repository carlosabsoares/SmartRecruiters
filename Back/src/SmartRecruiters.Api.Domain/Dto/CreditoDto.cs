using SmartRecruiters.Api.Domain.Enum;

namespace SmartRecruiters.Api.Domain.Dto
{
    public record CreditoDto
    {
        public string NumeroCredito { get; set; } = string.Empty;

        public string NumeroNfse { get; set; } = string.Empty;

        public DateTime DataConstituicao { get; set; }

        public decimal ValorIssqn { get; set; } = decimal.Zero;

        public string TipoCredito { get; set; } = EnumTipoCredito.Outros.ToString();

        public string SimplesNacional { get; set; } = string.Empty;

        public decimal Alicota { get; set; } = decimal.Zero;

        public decimal ValorFaturado { get; set; } = decimal.Zero;

        public decimal ValorDeducao { get; set; } = decimal.Zero;

        public decimal BaseCalculo { get; set; } = decimal.Zero;
    }
}