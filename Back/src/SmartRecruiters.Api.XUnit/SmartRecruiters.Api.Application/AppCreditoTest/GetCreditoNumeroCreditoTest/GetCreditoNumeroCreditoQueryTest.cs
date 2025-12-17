using SmartRecruiters.Api.Application.Commands.AppCredito;
using Xunit;

namespace SmartRecruiters.Api.XUnit.SmartRecruiters.Api.Application.AppCredito
{
    public class GetCreditoNumeroCreditoQueryTest
    {
        [Fact]
        public void Validate_GetCreditoNumeroCreditoQuery_WithValidData_ShouldBeValid()
        {
            var query = new GetCreditoNumeroCreditoQuery
            {
                numeroCredito = "CRD123456"
            };

            query.Validate();

            Assert.True(query.Valid);
            Assert.False(query.Invalid);
            Assert.True(query.Notifications.Count == 0);

            Assert.Equal(0, query.Notifications.Count);
            Assert.Equal("CRD123456", query.numeroCredito);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("sabfjbsdhfbhdsbfhbsdjhfhsd212das5das4dasd4adasdasdasdas")]
        public void Validate_GetCreditoNumeroCreditoQuery_WithInvalidData_ShouldBeNoValid(string numeroCredito)
        {
            var query = new GetCreditoNumeroCreditoQuery
            {
                numeroCredito = numeroCredito
            };

            query.Validate();

            var _notification = (List<Flunt.Notifications.Notification>)query.Notifications;

            Assert.False(query.Valid);
            Assert.True(query.Invalid);
            Assert.True(query.Notifications.Count > 0);

            Assert.True(_notification[0].Property == "numeroCredito");
            Assert.True(_notification[0].Message.Contains("numeroCredito"));
        }
    }
}