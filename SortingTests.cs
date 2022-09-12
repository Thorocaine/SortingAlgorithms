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

    [Fact]
    public void QuickSortLazyTest()
    {
        var sorted = _array.LazyQuickSort().ToArray();
        Assert.Equal(_ordered, sorted);
    }

    [Fact]
    public void QuickSortPivotOnFirstTest()
    {
        var uns = new [] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        QuickSort.Sort(uns, QuickSort.Pivot.First);
        Assert.Equal(new [] {1, 2, 3, 4, 5, 6, 7, 8,9, 10}, uns);
    }

    [Fact]
    public void QuickSortPivotOnMiddleTest()
    {
        var uns = new [] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        QuickSort.Sort(uns, QuickSort.Pivot.Middle);
        Assert.Equal(new [] {1, 2, 3, 4, 5, 6, 7, 8,9, 10}, uns);
    }

    [Fact]
    public void QuickSortPivotOnLastTest()
    {
        var uns = new [] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        QuickSort.Sort(uns, QuickSort.Pivot.First);
        Assert.Equal(new [] {1, 2, 3, 4, 5, 6, 7, 8,9, 10}, uns);
    }
    
}