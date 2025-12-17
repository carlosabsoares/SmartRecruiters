using Moq;
using SmartRecruiters.Api.Application.Commands.AppCredito;
using SmartRecruiters.Api.Domain.Entities;
using SmartRecruiters.Api.Domain.Repositories;
using Xunit;

namespace SmartRecruiters.Api.XUnit.SmartRecruiters.Api.Application.AppSmartRecruiters.AppCredito
{
    public class GetCreditoNumeroNfsesHandlerTest
    {
        private readonly Mock<ICreditoRepository> _creditoRepositoryMock;
        private readonly GetCreditoNumeroNfseHandler _handler;

        public GetCreditoNumeroNfsesHandlerTest()
        {
            _creditoRepositoryMock = new Mock<ICreditoRepository>();
            _handler = new GetCreditoNumeroNfseHandler(_creditoRepositoryMock.Object);
        }

        private GetCreditoNumeroNfseQuery validatedQuery = new GetCreditoNumeroNfseQuery()
        {
            NumeroNfse = "teste1"
        };

        private GetCreditoNumeroNfseQuery invalidatedQuery = new GetCreditoNumeroNfseQuery()
        {
            NumeroNfse = "sabfjbsdhfbhdsbfhbsdjhfhsd212das5das4dasd4adasdasdasdas"
        };

        [Fact]
        public async Task Handle_ValidGetCreditoNumeroNfseQuery_ShouldBeValid()
        {
            _creditoRepositoryMock.Setup(r => r.GetByNumeroNfes(It.IsAny<string>())).ReturnsAsync(new CreditoEntity()
            {
                NumeroCredito = "teste1",
                NumeroNfse = "teste1",
                DataConstituicao = DateTime.Now.Date,
                ValorIssqn = 1m,
                TipoCredito = "ISSQN",
                SimplesNacional = true,
                Aliquota = 5m,
                ValorFaturado = 10m,
                ValorDeducao = 20m,
                BaseCalculo = 3m
            });

            var result = await _handler.Handle(validatedQuery, CancellationToken.None);

            Assert.True(result.Success);
            Assert.NotNull(result.Data);

            _creditoRepositoryMock.Verify(x => x.GetByNumeroNfes(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidGetCreditoNumeroNfseQuery_Query_ShouldBeInvalid()
        {
            _creditoRepositoryMock.Setup(r => r.GetByNumeroNfes(It.IsAny<string>())).ReturnsAsync(new CreditoEntity()
            {
                NumeroCredito = "teste1",
                NumeroNfse = "teste1",
                DataConstituicao = DateTime.Now.Date,
                ValorIssqn = 1m,
                TipoCredito = "ISSQN",
                SimplesNacional = true,
                Aliquota = 5m,
                ValorFaturado = 10m,
                ValorDeducao = 20m,
                BaseCalculo = 3m
            });

            var result = await _handler.Handle(invalidatedQuery, CancellationToken.None);

            Assert.False(result.Success);

            _creditoRepositoryMock.Verify(x => x.AddRanger<CreditoEntity>(It.IsAny<IEnumerable<CreditoEntity>>()), Times.Never);
        }

        [Fact]
        public async Task Handle_InvalidGetCreditoNumeroNfseQuery_Found_ShouldValid()
        {
            _creditoRepositoryMock.Setup(r => r.GetByNumeroNfes(It.IsAny<string>())).ReturnsAsync(new CreditoEntity());

            var result = await _handler.Handle(validatedQuery, CancellationToken.None);

            Assert.True(result.Success);
            Assert.NotNull(result.Data);

            _creditoRepositoryMock.Verify(x => x.GetByNumeroNfes(It.IsAny<string>()), Times.Once);
        }
    }
}