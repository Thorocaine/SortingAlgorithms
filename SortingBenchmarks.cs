using BenchmarkDotNet.Attributes;

namespace SortingAlgorithms;

[MemoryDiagnoser(false)]
public class QuickSortBenchmarks
{
    [Params((int)1e1,(int)1e2, (int)1e3, (int)1e4, (int)1e5, (int)1e6, (int)1e7)] 
    public int n;
    
    List<int> _testData;
    int[] _data;

    [GlobalSetup]
    public void GlobalSetup() => _testData = Common.RandomArray(n).ToList();

    [IterationSetup]
    public void IterationSetup() => _data = _testData.ToArray();

    [Benchmark]
    public void BubbleSortTest()
    {
        if (_data.Length > 10000) return;
        BubbleSort.Sort(_data);
    }

    [Benchmark]
    public void SelectionSortTest()
    {
        if (_data.Length > 10000) return;
        SelectionSort.Sort(_data);
    }

    [Benchmark]
    public void InsertionSortTest()
    {
        if (_data.Length > 10000) return;
        InsertionSort.Sort(_data);
    }

    [Benchmark]
    public void ShellSortTest()
    {
        if (_data.Length > 10000) return;
        ShellSort.Sort(_data);
    }

    [Benchmark]
    public void MergeSortTest()
    {
        if (_data.Length > 10000) return;
        MergeSort.Sort(_data);
    }

    [Benchmark]
    [Arguments(QuickSort.Pivot.First)]
    [Arguments(QuickSort.Pivot.Middle)]
    [Arguments(QuickSort.Pivot.Last)]
    [Arguments(QuickSort.Pivot.SeventyFive)]
    [Arguments(QuickSort.Pivot.TwentyFive)]
    public void QuickSortTest(QuickSort.Pivot pivotAt) => QuickSort.Sort(_data, pivotAt);

    [Benchmark]
    [Arguments(QuickSort.Pivot.First)]
    [Arguments(QuickSort.Pivot.Middle)]
    [Arguments(QuickSort.Pivot.Last)]
    [Arguments(QuickSort.Pivot.SeventyFive)]
    [Arguments(QuickSort.Pivot.TwentyFive)]
    public void ParallelQuickSortTest(QuickSort.Pivot pivotAt) => QuickSort.SortParallel(_data, pivotAt);

    [Benchmark]
    public void FrameworkSort() => Array.Sort(_data);
}
