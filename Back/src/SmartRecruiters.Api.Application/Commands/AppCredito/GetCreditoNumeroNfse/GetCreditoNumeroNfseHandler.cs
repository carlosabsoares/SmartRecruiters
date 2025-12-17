using Flunt.Notifications;
using SmartRecruiters.Api.Application.Configuration.Events;
using SmartRecruiters.Api.Application.Configuration.Mapper;
using SmartRecruiters.Api.Application.Configuration.Queries;
using SmartRecruiters.Api.Domain.Dto;
using SmartRecruiters.Api.Domain.Repositories;

namespace SmartRecruiters.Api.Application.Commands.AppCredito
{
    public class GetCreditoNumeroNfseHandler : Notifiable, IQueryHandler<GetCreditoNumeroNfseQuery>
    {
        private readonly ICreditoRepository _repository;

        public GetCreditoNumeroNfseHandler(ICreditoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEvent> Handle(GetCreditoNumeroNfseQuery request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
                return new ResultEvent(false, request.Notifications);

            try
            {
                var result = new CreditoDto();

                var resultDataBase = await _repository.GetByNumeroNfes(request.NumeroNfse);

                if (!string.IsNullOrWhiteSpace(resultDataBase?.NumeroCredito))
                    result = CreditoMapper.CreditoDtoMapper(resultDataBase);

                return new ResultEvent(true, result != null ? result : null);
            }
            catch (Exception ex)
            {
                return new ResultEvent(false, ex.Message);
            }
        }
    }
}