using SmartRecruiters.Api.Application.Commands.AppCredito;
using Xunit;

namespace SmartRecruiters.Api.XUnit.SmartRecruiters.Api.Application.AppCredito
{
    public class CreateCreditoCommandTest
    {
        private CreateCreditoCommand BuildValidCommand()
        {
            return new CreateCreditoCommand
            {
                numeroCredito = "CRD123",
                numeroNfse = "NF123",
                dataConstituicao = DateTime.Now.Date,
                valorIssqn = 100m,
                tipoCredito = "Issqn", // valor válido no seu EnumTipoCredito
                simplesNacional = "sim",
                aliquota = 1m,
                valorFaturado = 1000m,
                valorDeducao = 10m,
                baseCalculo = 990m
            };
        }

        [Fact]
        public void Validate_CreateCreditoCommand_WithValidData_ShouldBeValid()
        {
            var command = new CreateCreditoCommand
            {
                aliquota = 5.0m,
                baseCalculo = 1000.0m,
                dataConstituicao = DateTime.Now.Date,
                numeroCredito = "CRD123456",
                numeroNfse = "NFSE123456",
                simplesNacional = "Sim",
                tipoCredito = "ISSQN",
                valorDeducao = 50.0m,
                valorFaturado = 2000.0m,
                valorIssqn = 150.0m
            };

            command.Validate();

            Assert.True(command.Valid);
            Assert.False(command.Invalid);
            Assert.True(command.Notifications.Count == 0);

            Assert.Equal(0, command.Notifications.Count);
            Assert.Equal(5.0m, command.aliquota);
            Assert.Equal(1000.0m, command.baseCalculo);
            Assert.Equal(DateTime.Now.Date, command.dataConstituicao);
            Assert.Equal("CRD123456", command.numeroCredito);
            Assert.Equal("NFSE123456", command.numeroNfse);
            Assert.Equal("Sim", command.simplesNacional);
            Assert.Equal("ISSQN", command.tipoCredito);
            Assert.Equal(50.0m, command.valorDeducao);
            Assert.Equal(2000.0m, command.valorFaturado);
            Assert.Equal(150.0m, command.valorIssqn);
        }

        [Theory]
        [InlineData(null, 1, 2, 3, 4)]
        [InlineData(0, 1, 2, 3, 4)]
        [InlineData(1, null, 3, 4, 5)]
        [InlineData(1, 0, 3, 4, 5)]
        [InlineData(1, 2, null, 4, 5)]
        [InlineData(1, 2, 0, 4, 5)]
        [InlineData(1, 2, 3, null, 5)]
        [InlineData(1, 2, 3, 0, 5)]
        [InlineData(1, 2, 3, 4, null)]
        [InlineData(1, 2, 3, 4, 0)]
        public void Validate_CreateCreditoCommand_WithInvalidDecimal_ShouldBeInvalid(decimal aliquota,
                                                                                     decimal baseCalculo,
                                                                                     decimal valorDeducao,
                                                                                     decimal valorFaturado,
                                                                                     decimal valorIssqn)
        {
            var command = new CreateCreditoCommand
            {
                aliquota = aliquota,
                baseCalculo = baseCalculo,
                dataConstituicao = DateTime.Now.Date,
                numeroCredito = "CRD123456",
                numeroNfse = "NFSE123456",
                simplesNacional = "Sim",
                tipoCredito = "ISSQN",
                valorDeducao = valorDeducao,
                valorFaturado = valorFaturado,
                valorIssqn = valorIssqn
            };
            var _notification = (List<Flunt.Notifications.Notification>)command.Notifications;

            command.Validate();

            Assert.False(command.Valid);
            Assert.True(command.Invalid);
            Assert.True(command.Notifications.Count > 0);

            Assert.True(_notification[0].Message.Contains("0"));
        }

        [Theory]
        [InlineData(null, null, null, null)]
        [InlineData("", "", "", "")]
        [InlineData("2", null, "Teste", "ISSQN")]
        [InlineData("2", "", "Teste", "ISSQN")]
        [InlineData("2", "CRD123456", "", "ISSQN")]
        [InlineData("sabfjbsdhfbhdsbfhbsdjhfhsd212das5das4dasd4adasdasdasd", "CRD123456", "Sim", "ISSQN")]
        [InlineData("teste", "sabfjbsdhfbhdsbfhbsdjhfhsd212das5das4dasd4adasdasdasd", "Sim", "ISSQN")]
        [InlineData("2", "CRD123456", "sabfjbsdhfbhdsbfhbsdjhfhsd212das5das4dasd4adasdasdasd", "ISSQN")]
        [InlineData("2", "CRD123456", "Sim", "sabfjbsdhfbhdsbfhbsdjhfhsd212das5das4dasd4adasdasdasd")]
        public void Validate_CreateCreditoCommand_WithStrings_ShouldBeInvalid(string numeroCredito, string numeroNfse, string simplesNacional, string tipoCredito)
        {
            var command = new CreateCreditoCommand
            {
                aliquota = 5.0m,
                baseCalculo = 1000.0m,
                dataConstituicao = DateTime.Now.Date,
                numeroCredito = numeroCredito,
                numeroNfse = numeroNfse,
                simplesNacional = simplesNacional,
                tipoCredito = tipoCredito,
                valorDeducao = 50.0m,
                valorFaturado = 2000.0m,
                valorIssqn = 150.0m
            };
            var _notification = (List<Flunt.Notifications.Notification>)command.Notifications;

            command.Validate();

            Assert.False(command.Valid);
            Assert.True(command.Invalid);
            Assert.True(command.Notifications.Count > 0);
        }

        [Fact]
        public void Validate_WithInvalidCommand_ShouldHaveOk()
        {
            var commandItem = new CreateCreditoCommand
            {
                numeroCredito = "teste",
                numeroNfse = "teste",
                dataConstituicao = default,
                valorIssqn = 1m,
                tipoCredito = "ISSQN",
                simplesNacional = "Não",
                aliquota = 5m,
                valorFaturado = 10m,
                valorDeducao = 20m,
                baseCalculo = 3m
            };

            var command = new CreateCreditoCommandCollection
            {
                commandItem
            };

            command.Validate();

            Assert.True(command[0].Valid);
            Assert.False(command[0].Invalid);
        }

        [Fact]
        public void Validate_WithInvalidCommand_ShouldHaveNotifications()
        {
            var valid = BuildValidCommand();

            var invalid = new CreateCreditoCommand
            {
                // força vários erros
                numeroCredito = null,
                numeroNfse = null,
                dataConstituicao = default,
                valorIssqn = 0m,
                tipoCredito = null,
                simplesNacional = null,
                aliquota = 0m,
                valorFaturado = 0m,
                valorDeducao = 0m,
                baseCalculo = 0m
            };

            var command = new CreateCreditoCommandCollection
            {
                valid,
                invalid
            };

            command.Validate();

            // Assert
            Assert.False(valid.Valid);
            Assert.True(valid.Invalid);
        }

        [Fact]
        public void Validate_EmptyCollection_ShouldNotThrow()
        {
            var collection = new CreateCreditoCommandCollection();

            collection.Validate();

            Assert.Empty(collection); // apenas garante que o método roda sem erro
        }
    }
}