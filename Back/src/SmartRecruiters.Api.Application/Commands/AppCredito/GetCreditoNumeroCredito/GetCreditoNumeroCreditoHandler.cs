using Flunt.Notifications;
using SmartRecruiters.Api.Application.Configuration.Events;
using SmartRecruiters.Api.Application.Configuration.Mapper;
using SmartRecruiters.Api.Application.Configuration.Queries;
using SmartRecruiters.Api.Domain.Dto;
using SmartRecruiters.Api.Domain.Repositories;

namespace SmartRecruiters.Api.Application.Commands.AppCredito
{
    public class GetCreditoNumeroCreditoHandler : Notifiable, IQueryHandler<GetCreditoNumeroCreditoQuery>
    {
        private readonly ICreditoRepository _repository;

        public GetCreditoNumeroCreditoHandler(ICreditoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEvent> Handle(GetCreditoNumeroCreditoQuery request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
                return new ResultEvent(false, request.Notifications);

            try
            {
                CreditoDto? result = null;

                var resultDataBase = await _repository.GetByNumeroCredito(request.numeroCredito);

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