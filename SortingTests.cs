using Xunit;

namespace SortingAlgorithms;

public class SortingTests
{
    readonly int[] _array;
    readonly int[] _ordered;

    public SortingTests()
    {
        _array = Common.RandomArray(1000);
        _ordered = _array.OrderBy(x => x).ToArray();
    }

    [Fact]
    public void BubbleSortTest()
    {
        BubbleSort.Sort(_array);
        Assert.Equal(_ordered, _array);
    }

    [Fact]
    public void SelectionSortTest()
    {
        SelectionSort.Sort(_array);
        Assert.Equal(_ordered, _array);
    }

    [Fact]
    public void InsertionSortTest()
    {
        InsertionSort.Sort(_array);
        Assert.Equal(_ordered, _array);
    }

    [Fact]
    public void ShellSortTest()
    {
        ShellSort.Sort(_array);
        Assert.Equal(_ordered, _array);
    }

    [Fact]
    public void MergeSortTest()
    {
        MergeSort.Sort(_array);
        Assert.Equal(_ordered, _array);
    }
 
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
}