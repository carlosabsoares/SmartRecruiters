using Flunt.Notifications;
using Flunt.Validations;
using SmartRecruiters.Api.Application.Configuration.Commands;
using SmartRecruiters.Api.Domain.Enum;

namespace SmartRecruiters.Api.Application.Commands.AppCredito
{
    public class CreateCreditoCommand : Notifiable, ICommand
    {
        public string numeroCredito { get; set; }
        public string numeroNfse { get; set; }
        public DateTime dataConstituicao { get; set; }
        public decimal valorIssqn { get; set; }
        public string tipoCredito { get; set; }
        public string simplesNacional { get; set; }
        public decimal aliquota { get; set; }
        public decimal valorFaturado { get; set; }
        public decimal valorDeducao { get; set; }
        public decimal baseCalculo { get; set; }

        public void Validate()
        {
            var contract = new Contract()
                .Requires();

            // numeroCredito: se for nulo, já adiciona erro; se não, valida tamanho
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

            // numeroNfse pode ser nulo nos testes
            if (string.IsNullOrWhiteSpace(numeroNfse))
            {
                contract.IsNotNullOrWhiteSpace(numeroNfse,
                    "numeroNfse", "numeroNfse é obrigatório");
            }
            else
            {
                contract
                    .IsGreaterOrEqualsThan(numeroNfse.Length, 1,
                        "numeroNfse", "numeroNfse deve ter pelo menos 1 dígito")
                    .IsLowerOrEqualsThan(numeroNfse.Length, 50,
                        "numeroNfse", "numeroNfse não pode ter mais de 50 dígitos");
            }

            contract
                .IsNotNull(dataConstituicao, "dataConstituicao", "dataConstituicao é obrigatório")
                .IsNotNull(valorIssqn, "valorIssqn", "valorIssqn é obrigatório")
                .IsGreaterOrEqualsThan(valorIssqn, 0.1, "valorIssqn", "valorIssqn deve ser maior que 0");

            // tipoCredito: tratar nulo antes de usar Length
            if (string.IsNullOrWhiteSpace(tipoCredito))
            {
                contract.IsNotNull(tipoCredito, "tipoCredito", "tipoCredito é obrigatório");
            }
            else
            {
                contract
                    .IsTrue(IsValidTipoCredito(tipoCredito),
                        "tipoCredito", "tipoCredito inválido")
                    .IsGreaterOrEqualsThan(tipoCredito.Length, 1,
                        "tipoCredito", "tipoCredito deve ter pelo menos 1 dígito")
                    .IsLowerOrEqualsThan(tipoCredito.Length, 50,
                        "tipoCredito", "tipoCredito não pode ter mais de 50 dígitos");
            }

            // simplesNacional: também pode vir nulo
            if (string.IsNullOrWhiteSpace(simplesNacional))
            {
                contract.IsNotNullOrWhiteSpace(simplesNacional,
                    "simplesNacional", "simplesNacional é obrigatório");
            }
            else
            {
                contract.IsTrue(IsBoolean(simplesNacional),
                    "simplesNacional", "simplesNacional deve ser sim ou não");
                contract
                    .IsGreaterOrEqualsThan(simplesNacional.Length, 1,
                        "simplesNacional", "simplesNacional deve ter pelo menos 1 dígito")
                    .IsLowerOrEqualsThan(simplesNacional.Length, 50,
                        "simplesNacional", "simplesNacional não pode ter mais de 50 dígitos");
            }

            contract
                .IsGreaterOrEqualsThan(aliquota, 0.1, "aliquota", "aliquota deve ser maior que 0")
                .IsGreaterOrEqualsThan(valorFaturado, 0.1, "valorFaturado", "valorFaturado deve ser maior que 0")
                .IsGreaterOrEqualsThan(valorDeducao, 0.1, "valorDeducao", "valorDeducao deve ser maior que 0")
                .IsGreaterOrEqualsThan(baseCalculo, 0.1, "baseCalculo", "baseCalculo deve ser maior que 0");

            AddNotifications(contract);
        }

        private bool IsBoolean(string value)
        {
            var v = value?.Trim().ToLower();
            return v == "sim" || v == "não" || v == "nao";
        }

        public static bool IsValidTipoCredito(string value)
        {
            return Enum.IsDefined(typeof(EnumTipoCredito), value);
        }
    }

    public class CreateCreditoCommandCollection : List<CreateCreditoCommand>, ICommand
    {
        public void Validate()
        {
            foreach (var command in this)
                command.Validate();
        }
    }
}