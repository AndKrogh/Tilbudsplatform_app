using Microsoft.EntityFrameworkCore;
using Moq;
using TilbudsPlatform.core.Data;
using TilbudsPlatform.core.Entities;
using TilbudsPlatform.core.Services;
using Xunit;

public class CustomerServiceTests
{
    [Fact]
    public async Task GetByIdAsync_ShouldReturnCustomer_WhenCustomerExists()
    {
        var mockData = new List<Customer>
        {
            new Customer { Id = 1, Name = "John Doe", Email = "john@example.com" },
            new Customer { Id = 2, Name = "Jane Doe", Email = "jane@example.com" }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Customer>>();
        mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(mockData.Provider);
        mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(mockData.Expression);
        mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(mockData.ElementType);
        mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator());

        var mockOptions = new Mock<DbContextOptions<TilbudsPlatformContext>>();

        var mockContext = new Mock<TilbudsPlatformContext>(mockOptions.Object);

        mockContext.Setup(c => c.Set<Customer>()).Returns(mockSet.Object);

        var service = new CustomerService(mockContext.Object);

        var result = await service.GetByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal("John Doe", result.Name);
        Assert.Equal("john@example.com", result.Email);
    }
}
