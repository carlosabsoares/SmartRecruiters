using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SmartRecruiters.Api.Api.Controllers;
using SmartRecruiters.Api.Application.Commands.AppCredito;
using SmartRecruiters.Api.Application.Configuration.Events;
using SmartRecruiters.Api.Domain.Dto;
using Xunit;

namespace SmartRecruiters.Api.XUnit.SmartRecruiters.Api.Api.Controllers
{
    public class CreditoControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly CreditoController _controller;

        public CreditoControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new CreditoController(_mediatorMock.Object);
        }

        [Fact]
        public async Task PostCreateCredito_Success_ShouldBeOk()
        {
            var command = new CreateCreditoCommandCollection();
            var expectedResult = new ResultEvent(true, true);

            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            var result = await _controller.PostCreateCredito(command);

            Assert.Equal(202, ((ObjectResult)result).StatusCode);
            Assert.Equal(true, ((ObjectResult)result).Value);
        }

        [Fact]
        public async Task PostCreateCredito_Success_ShouldBeNOk()
        {
            var command = new CreateCreditoCommandCollection();
            var expectedResult = new ResultEvent(false, false);

            _mediatorMock
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            var result = await _controller.PostCreateCredito(command);

            Assert.Equal(400, ((ObjectResult)result).StatusCode);
            Assert.Equal(false, ((ObjectResult)result).Value);
        }

        [Fact]
        public async Task GetCreditoNumeroNfs_Success_ShouldBeOk()
        {
            var numeroNfse = "12345";

            var expectedResult = new ResultEvent(true, new List<CreditoDto>());

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetCreditoNumeroNfseQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            var result = await _controller.GetCreditoNumeroNfs(numeroNfse);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(expectedResult.Data, okResult.Value);
        }

        [Fact]
        public async Task GetCreditoNumeroCredito_Success_ShouldBeOk()
        {
            var numeroCredito = "12345";

            var expectedResult = new ResultEvent(true, new List<CreditoDto>());

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetCreditoNumeroCreditoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            var result = await _controller.GetCreditoNumeroCredito(numeroCredito);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(expectedResult.Data, okResult.Value);
        }
    }
}