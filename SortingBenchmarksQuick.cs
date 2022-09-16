using BenchmarkDotNet.Attributes;

namespace SortingAlgorithms;

public partial class QuickSortBenchmarks
{
    [Benchmark]
    [Arguments(QuickSort.Pivot.First)]
    [Arguments(QuickSort.Pivot.Middle)]
    [Arguments(QuickSort.Pivot.Last)]
    [Arguments(QuickSort.Pivot.SeventyFive)]
    [Arguments(QuickSort.Pivot.TwentyFive)]
    public void QuickSortTest(QuickSort.Pivot pivotAt) => 
        QuickSort.Sort(_data, pivotAt);

    [Benchmark]
    [Arguments(QuickSort.Pivot.First)]
    [Arguments(QuickSort.Pivot.Middle)]
    [Arguments(QuickSort.Pivot.Last)]
    [Arguments(QuickSort.Pivot.SeventyFive)]
    [Arguments(QuickSort.Pivot.TwentyFive)]
    public void ParallelQuickSortTest(QuickSort.Pivot pivotAt) => 
        QuickSort.SortParallel(_data, pivotAt);
}
