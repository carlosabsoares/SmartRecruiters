using Moq;
using SmartRecruiters.Api.Domain.Entities;
using SmartRecruiters.Api.Domain.Repositories;
using Xunit;

public class CreditoRepositoryTests
{
    [Fact]
    public async Task AddRange_ShouldReturnOK()
    {
        // Arrange
        var mock = new Mock<ICreditoRepository>();

        mock.Setup(repo => repo.AddRanger(It.IsAny<IEnumerable<CreditoEntity>>())).ReturnsAsync(true);

        var service = mock.Object;

        // Act
        var result = await service.AddRanger(new List<CreditoEntity>());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task AddRange_ShouldReturnNOK()
    {
        // Arrange
        var mock = new Mock<ICreditoRepository>();

        mock.Setup(repo => repo.AddRanger(It.IsAny<IEnumerable<CreditoEntity>>())).ReturnsAsync(false);

        var service = mock.Object;

        // Act
        var result = await service.AddRanger(new List<CreditoEntity>());

        // Assert
        Assert.False(result);
    }

    //[Fact]
    //public async Task Update_ShouldThrowException()
    //{
    //    // Arrange
    //    var mock = new Mock<ICudRepository>();

    //    mock.Setup(repo => repo.Update(It.IsAny<ProjectEntity>()))
    //        .ThrowsAsync(new Exception("Erro ao atualizar"));

    //    var repo = mock.Object;

    //    // Act & Assert
    //    var ex = await Assert.ThrowsAsync<Exception>(() => repo.Update(new ProjectEntity()));
    //    Assert.Equal("Erro ao atualizar", ex.Message);
    //}

    //[Fact]
    //public async Task TransactionMethods_ShouldReturnExpectedResults()
    //{
    //    var mock = new Mock<ICudRepository>();

    //    mock.Setup(x => x.BeginTransactionAsync()).ReturnsAsync(true);
    //    mock.Setup(x => x.CommitTransactionAsync()).ReturnsAsync(false);
    //    mock.Setup(x => x.RollbackTransactionAsync()).ReturnsAsync(true);

    //    var repo = mock.Object;

    //    Assert.True(await repo.BeginTransactionAsync());
    //    Assert.False(await repo.CommitTransactionAsync());
    //    Assert.True(await repo.RollbackTransactionAsync());
    //}
}