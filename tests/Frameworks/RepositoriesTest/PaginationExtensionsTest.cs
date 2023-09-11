using Hermes.Frameworks.Repositories.DataStructures;

namespace Hermes.Frameworks.RepositoriesTest;

public class PaginationExtensionsTest
{
    [Fact]
    public void ToPage_ValidOffset_ValidPage()
    {
        // Arrange
        var offset = Offset.Of(1, 3);
        var sut = Enumerable.Range(1, 10);

        // Act
        var actual = sut.ToPage(sut.Count(), offset);

        // Assert
        Assert.Equal(1, actual.PageIndex);
        Assert.Equal(3, actual.PageSize);
        Assert.Equal(sut, actual);
    }
}