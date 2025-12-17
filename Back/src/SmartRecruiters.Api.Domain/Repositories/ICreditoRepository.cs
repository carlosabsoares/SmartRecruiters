using SmartRecruiters.Api.Domain.Entities;

namespace SmartRecruiters.Api.Domain.Repositories
{
    public interface ICreditoRepository : ICudRepository
    {
        Task<CreditoEntity?> GetByNumeroNfes(string numeroNfes);

        Task<CreditoEntity?> GetByNumeroCredito(string numeroCredito);
    }
}