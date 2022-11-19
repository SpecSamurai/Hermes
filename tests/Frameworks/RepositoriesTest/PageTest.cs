using Hermes.Frameworks.Repositories.DataStructures;

namespace RepositoriesTest;

public class PageTest
{
    private const int ValidCount = 0;
    private const int InvalidCount = -1;
    private const int ValidPageIndex = 0;
    private const int InvalidPageIndex = -1;
    private const int ValidPageSize = 1;
    private const int InvalidPageSize = 0;

    [Fact]
    public void Constructor_InvalidCount_ThrowArgumentException()
    {
        // Arrange & Act
        var action = () => new Page<int>(
            pageCollection: new List<int>(),
            totalCount: InvalidCount,
            pageIndex: ValidPageIndex,
            pageSize: ValidPageSize);

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void Constructor_InvalidPageIndex_ThrowArgumentException()
    {
        // Arrange & Act
        var action = () => new Page<int>(
            pageCollection: new List<int>(),
            totalCount: ValidCount,
            pageIndex: InvalidPageIndex,
            pageSize: ValidPageSize);

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void Constructor_InvalidPageSize_ThrowArgumentException()
    {
        // Arrange & Act
        var action = () => new Page<int>(
            pageCollection: new List<int>(),
            totalCount: ValidCount,
            pageIndex: ValidPageIndex,
            pageSize: InvalidPageSize);

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void Constructor_InvalidList_ThrowArgumentException()
    {
        // Arrange & Act
        var action = () => new Page<int>(
            pageCollection: Enumerable.Range(1, 10).ToList(),
            totalCount: ValidCount,
            pageIndex: ValidPageIndex,
            pageSize: ValidPageSize);

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void ToList_ValidPage_List()
    {
        // Arrange
        var exprectedList = new List<int> { 1, 2, 3 };
        var sut = new Page<int>(
            exprectedList,
            totalCount: exprectedList.Count,
            pageIndex: ValidPageIndex,
            pageSize: exprectedList.Count);

        // Act
        var actual = sut.ToList();

        // Assert
        Assert.Equal(exprectedList, actual);
    }

    [Theory]
    [InlineData(5, 2, 3)]
    [InlineData(6, 2, 3)]
    [InlineData(5, 6, 1)]
    [InlineData(5, 5, 1)]
    public void TotalPages_ValidPage_ValidTotalCount(int totalCount, int pageSize, int expected)
    {
        // Arrange
        var sut = new Page<int>(
            Enumerable.Empty<int>().ToList(),
            totalCount: totalCount,
            pageIndex: ValidPageIndex,
            pageSize: pageSize);

        // Act
        var actual = sut.TotalPages;

        // Assert
        Assert.Equal(expected, actual);
    }
}