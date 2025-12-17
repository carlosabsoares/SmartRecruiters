using Flunt.Notifications;
using SmartRecruiters.Api.Application.Configuration.Commands;
using SmartRecruiters.Api.Application.Configuration.Events;
using SmartRecruiters.Api.Domain.Entities;
using SmartRecruiters.Api.Domain.Repositories;

namespace SmartRecruiters.Api.Application.Commands.AppCredito
{
    public class CreateCreditoHandler : Notifiable, ICommandHandler<CreateCreditoCommandCollection>
    {
        private readonly ICreditoRepository _repository;

        public CreateCreditoHandler(ICreditoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEvent> Handle(CreateCreditoCommandCollection request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Any(r => r.Notifications.Any()))
            {
                return new ResultEvent(false, request.SelectMany(r => r.Notifications).ToList());
            }

            var entities = request.Select(r => new CreditoEntity
            {
                NumeroCredito = r.numeroCredito.Trim(),
                NumeroNfse = r.numeroNfse.Trim(),
                DataConstituicao = DateTime.Now.Date,
                ValorIssqn = r.valorIssqn,
                TipoCredito = r.tipoCredito.Trim(),
                SimplesNacional = (r.simplesNacional.Trim().ToLower() == "sim") ? true : false,
                Aliquota = r.aliquota,
                ValorFaturado = r.valorFaturado,
                ValorDeducao = r.valorDeducao,
                BaseCalculo = r.baseCalculo,
            }).ToList();

            try
            {
                var result = await _repository.AddRanger(entities);

                return new ResultEvent(result, result ? result : null);
            }
            catch (Exception ex)
            {
                return new ResultEvent(false, ex.Message);
            }
        }
    }
}