using Flunt.Notifications;
using Flunt.Validations;
using SmartRecruiters.Api.Application.Configuration.Queries;

namespace SmartRecruiters.Api.Application.Commands.AppCredito
{
    public class GetCreditoNumeroCreditoQuery : Notifiable, IQuery
    {
        public string numeroCredito { get; set; }

        public void Validate()
        {
            var contract = new Contract()
                .Requires();

            if (string.IsNullOrWhiteSpace(numeroCredito))
            {
                contract.IsNotNullOrWhiteSpace(numeroCredito,
                    "numeroCredito", "numeroCredito é obrigatorio");
            }
            else
            {
                contract
                    .IsGreaterOrEqualsThan(numeroCredito.Length, 1,
                        "numeroCredito", "numeroCredito deve ter pelo menos 1 dígito")
                    .IsLowerOrEqualsThan(numeroCredito.Length, 50,
                        "numeroCredito", "numeroCredito não pode ter mais de 50 dígitos");
            }

            AddNotifications(contract);
        }
    }
}