using Microsoft.EntityFrameworkCore;
using SmartRecruiters.Api.Domain.Entities;
using SmartRecruiters.Api.Domain.Repositories;
using SmartRecruiters.Api.Infra.Context;

namespace SmartRecruiters.Api.Infra.Repositories
{
    public class CreditoRepository : CudRepository, ICreditoRepository
    {
        private readonly DataContext _context;

        public CreditoRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CreditoEntity?> GetByNumeroCredito(string numeroCredito)
        {
            if (string.IsNullOrWhiteSpace(numeroCredito))
                return null;

            var normalized = numeroCredito.Trim().ToLowerInvariant();

            var result = await _context.Credito
                                       .SingleOrDefaultAsync(c => c.NumeroCredito.ToLower() == normalized);

            if (result == null)
                return result;

            return result;
        }

        public async Task<CreditoEntity?> GetByNumeroNfes(string numeroNfes)
        {
            if (string.IsNullOrWhiteSpace(numeroNfes))
                return null;

            var normalized = numeroNfes.Trim().ToLowerInvariant();

            var result = await _context.Credito
                .SingleOrDefaultAsync(c => c.NumeroNfse.ToLower() == normalized);

            if (result == null)
                return result;

            return result;
        }
    }
}