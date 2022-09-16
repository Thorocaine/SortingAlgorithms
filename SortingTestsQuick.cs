using Xunit;

namespace SortingAlgorithms;

public partial class SortingTests
{
    [Theory]
    [InlineData(QuickSort.Pivot.First)]
    [InlineData(QuickSort.Pivot.Middle)]
    [InlineData(QuickSort.Pivot.Last)]
    [InlineData(QuickSort.Pivot.SeventyFive)]
    [InlineData(QuickSort.Pivot.TwentyFive)]
    public void QuickSortPivotTest(QuickSort.Pivot pivot)
    {
        QuickSort.Sort(_array, pivot);
        Assert.Equal(_ordered, _array);
    }

    [Theory]
    [InlineData(QuickSort.Pivot.First)]
    [InlineData(QuickSort.Pivot.Middle)]
    [InlineData(QuickSort.Pivot.Last)]
    [InlineData(QuickSort.Pivot.SeventyFive)]
    [InlineData(QuickSort.Pivot.TwentyFive)]
    public void ParallelQuickSortPivotTest(QuickSort.Pivot pivot)
    {
        QuickSort.SortParallel(_array, pivot);
        Assert.Equal(_ordered, _array);
    }
}