using SmartRecruiters.Api.Domain.Dto;
using SmartRecruiters.Api.Domain.Entities;

namespace SmartRecruiters.Api.Application.Configuration.Mapper
{
    public static class CreditoMapper
    {
        public static CreditoDto CreditoDtoMapper(CreditoEntity resultDataBase)
        {
            return new CreditoDto()
            {
                Alicota = resultDataBase.Aliquota,
                BaseCalculo = resultDataBase.BaseCalculo,
                DataConstituicao = resultDataBase.DataConstituicao,
                NumeroCredito = resultDataBase.NumeroCredito,
                NumeroNfse = resultDataBase.NumeroNfse,
                SimplesNacional = resultDataBase.SimplesNacional ? "Sim" : "False",
                TipoCredito = resultDataBase.TipoCredito,
                ValorDeducao = resultDataBase.ValorDeducao,
                ValorFaturado = resultDataBase.ValorFaturado,
                ValorIssqn = resultDataBase.ValorIssqn
            };
        }
    }
}