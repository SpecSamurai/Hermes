namespace Hermes.Frameworks.RepositoriesTest;

public class PaginationExtensionsTest
{
    [Fact]
    public void ToPage_InvalidCount_ThrowArgumentException()
    {
        // Arrange
        var exprectedList = new List<int> { 4, 5, 6 };
        var expectedPageIndex = 1;
        var expectedPageSize = 3;

        var sut = Enumerable.Range(1, 10);

        // Act
        var actial = sut.ToPage(expectedPageIndex, expectedPageSize);

        // Assert
        Assert.Equal(actial.PageIndex, expectedPageIndex);
        Assert.Equal(actial.PageSize, expectedPageSize);
        Assert.Equal(actial, exprectedList);
    }
}