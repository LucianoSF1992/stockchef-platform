using StockChef.Domain.Entities;
using StockChef.Domain.Enums;

namespace StockChef.UnitTests;

public class StockMovementTests
{
    [Fact]
    public void Should_Create_Entry_Movement_With_Valid_Data()
    {
        // Arrange
        var productId = Guid.NewGuid();

        // Act
        var movement = new StockMovement(
            productId,
            StockMovementType.Entry,
            10,
            "Compra de mercadorias");

        // Assert
        Assert.Equal(productId, movement.ProductId);
        Assert.Equal(StockMovementType.Entry, movement.Type);
        Assert.Equal(10, movement.Quantity);
        Assert.Equal("Compra de mercadorias", movement.Reason);
    }

    [Fact]
    public void Should_Create_Exit_Movement_With_Valid_Data()
    {
        // Arrange
        var productId = Guid.NewGuid();

        // Act
        var movement = new StockMovement(
            productId,
            StockMovementType.Exit,
            5,
            "Venda");

        // Assert
        Assert.Equal(productId, movement.ProductId);
        Assert.Equal(StockMovementType.Exit, movement.Type);
        Assert.Equal(5, movement.Quantity);
        Assert.Equal("Venda", movement.Reason);
    }

    [Fact]
    public void Should_Create_Adjustment_Movement_With_Valid_Data()
    {
        // Arrange
        var productId = Guid.NewGuid();

        // Act
        var movement = new StockMovement(
            productId,
            StockMovementType.Adjustment,
            3,
            "Ajuste de inventário");

        // Assert
        Assert.Equal(productId, movement.ProductId);
        Assert.Equal(StockMovementType.Adjustment, movement.Type);
        Assert.Equal(3, movement.Quantity);
    }

    [Fact]
    public void Should_Create_Loss_Movement_With_Valid_Data()
    {
        // Arrange
        var productId = Guid.NewGuid();

        // Act
        var movement = new StockMovement(
            productId,
            StockMovementType.Loss,
            2,
            "Produto danificado");

        // Assert
        Assert.Equal(productId, movement.ProductId);
        Assert.Equal(StockMovementType.Loss, movement.Type);
        Assert.Equal(2, movement.Quantity);
    }

    [Fact]
    public void Should_Reject_Zero_Quantity()
    {
        // Arrange
        var productId = Guid.NewGuid();

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>
            new StockMovement(
                productId,
                StockMovementType.Entry,
                0));

        Assert.Equal(
            "Quantity must be greater than zero.",
            exception.Message);
    }

    [Fact]
    public void Should_Reject_Negative_Quantity()
    {
        // Arrange
        var productId = Guid.NewGuid();

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>
            new StockMovement(
                productId,
                StockMovementType.Entry,
                -5));

        Assert.Equal(
            "Quantity must be greater than zero.",
            exception.Message);
    }

    [Fact]
    public void Should_Allow_Movement_Without_Reason()
    {
        // Arrange
        var productId = Guid.NewGuid();

        // Act
        var movement = new StockMovement(
            productId,
            StockMovementType.Entry,
            10);

        // Assert
        Assert.Null(movement.Reason);
    }
}
