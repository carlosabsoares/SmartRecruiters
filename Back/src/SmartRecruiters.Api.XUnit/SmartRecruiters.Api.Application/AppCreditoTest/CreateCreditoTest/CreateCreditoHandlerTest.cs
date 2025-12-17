using Moq;
using SmartRecruiters.Api.Application.Commands.AppCredito;
using SmartRecruiters.Api.Domain.Entities;
using SmartRecruiters.Api.Domain.Repositories;
using Xunit;

namespace SmartRecruiters.Api.XUnit.SmartRecruiters.Api.Application.AppSmartRecruiters.AppCredito
{
    public class CreateCreditoHandlerTest
    {
        private readonly Mock<ICreditoRepository> _creditoRepositoryMock;
        private readonly CreateCreditoHandler _handler;

        public CreateCreditoHandlerTest()
        {
            _creditoRepositoryMock = new Mock<ICreditoRepository>();
            _handler = new CreateCreditoHandler(_creditoRepositoryMock.Object);
        }

        private CreateCreditoCommandCollection createCreditoCommandCollection = new CreateCreditoCommandCollection()
        {
            new CreateCreditoCommand()
            {
                numeroCredito = "teste1",
                numeroNfse = "teste1",
                dataConstituicao = DateTime.Now.Date,
                valorIssqn = 1m,
                tipoCredito = "ISSQN",
                simplesNacional = "Não",
                aliquota = 5m,
                valorFaturado = 10m,
                valorDeducao = 20m,
                baseCalculo = 3m
            }
        };

        [Fact]
        public async Task Handle_ValidCreation_ShouldBeValid()
        {
            _creditoRepositoryMock.Setup(r => r.AddRanger<CreditoEntity>(It.IsAny<IEnumerable<CreditoEntity>>())).ReturnsAsync(true);

            var result = await _handler.Handle(createCreditoCommandCollection, CancellationToken.None);

            Assert.True(result.Success);
            Assert.True((bool)result.Data);

            _creditoRepositoryMock.Verify(x => x.AddRanger<CreditoEntity>(It.IsAny<IEnumerable<CreditoEntity>>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ValidCreation_ShouldBeInvalid()
        {
            _creditoRepositoryMock.Setup(r => r.AddRanger<CreditoEntity>(It.IsAny<IEnumerable<CreditoEntity>>())).ReturnsAsync(false);

            var result = await _handler.Handle(createCreditoCommandCollection, CancellationToken.None);

            Assert.False(result.Success);
            Assert.Null(result.Data);

            _creditoRepositoryMock.Verify(x => x.AddRanger<CreditoEntity>(It.IsAny<IEnumerable<CreditoEntity>>()), Times.Once);
        }

        [Fact]
        public async Task Handle_RepositoryThrows_ShouldReturnError()
        {
            _creditoRepositoryMock
                .Setup(r => r.AddRanger<CreditoEntity>(It.IsAny<IEnumerable<CreditoEntity>>()))
                .ThrowsAsync(new Exception("erro ao salvar"));

            var result = await _handler.Handle(createCreditoCommandCollection, CancellationToken.None);

            Assert.False(result.Success);
            Assert.Equal("erro ao salvar", result.Data);

            _creditoRepositoryMock.Verify(
                x => x.AddRanger<CreditoEntity>(It.IsAny<IEnumerable<CreditoEntity>>()),
                Times.Once);
        }
    }
}