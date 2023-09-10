using Hermes.Frameworks.Repositories.DataStructures;

namespace Hermes.Frameworks.RepositoriesTest;

public class PaginationExtensionsTest
{
    [Fact]
    public void ToPage_ValidInput_ValidPage()
    {
        // Arrange
        var expectedList = new List<int> { 4, 5, 6 };
        var expectedPageIndex = 1;
        var expectedPageSize = 3;

        var sut = Enumerable.Range(1, 10);

        // Act
        var actual = sut.ToPage(sut.Count(), expectedPageIndex, expectedPageSize);

        // Assert
        Assert.Equal(expectedPageIndex, actual.PageIndex);
        Assert.Equal(expectedPageSize, actual.PageSize);
        Assert.Equal(expectedList, actual);
    }

    [Fact]
    public void ToPage_ValidOffset_ValidPage()
    {
        // Arrange
        var expectedList = new List<int> { 4, 5, 6 };
        var offset = Offset.Of(1, 3);

        var sut = Enumerable.Range(1, 10);

        // Act
        var actual = sut.ToPage(sut.Count(), offset);

        // Assert
        Assert.Equal(1, actual.PageIndex);
        Assert.Equal(3, actual.PageSize);
        Assert.Equal(expectedList, actual);
    }
}