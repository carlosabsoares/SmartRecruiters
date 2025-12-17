using Flunt.Notifications;
using Flunt.Validations;
using SmartRecruiters.Api.Application.Configuration.Queries;

namespace SmartRecruiters.Api.Application.Commands.AppCredito
{
    public class GetCreditoNumeroNfseQuery : Notifiable, IQuery
    {
        public string NumeroNfse { get; set; }

        public void Validate()
        {
            var contract = new Contract()
                .Requires();

            if (string.IsNullOrWhiteSpace(NumeroNfse))
            {
                contract.IsNotNullOrWhiteSpace(NumeroNfse,
                    "NumeroNfse", "NumeroNfse é obrigatorio");
            }
            else
            {
                contract
                    .IsGreaterOrEqualsThan(NumeroNfse.Length, 1,
                        "NumeroNfse", "NumeroNfse deve ter pelo menos 1 dígito")
                    .IsLowerOrEqualsThan(NumeroNfse.Length, 50,
                        "NumeroNfse", "NumeroNfse não pode ter mais de 50 dígitos");
            }

            AddNotifications(contract);
        }
    }
}