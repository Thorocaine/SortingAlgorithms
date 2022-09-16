namespace SortingAlgorithms;

public static partial class QuickSort
{
    public static void SortParallel(int[] array, Pivot pivot) =>
        SortParallel(array, GetPivotFunc(pivot), 0, array.Length - 1);

    static void SortParallel(int[] array, GetPivot getPivot, int lower, int upper)
    {
        if (lower >= upper) return;
        if (upper - lower <= 1000) { Sort(array, getPivot, lower, upper); return; }
        var pivot = Partition(array, getPivot, lower, upper);
        Parallel.Invoke(
            () => { if (pivot > 1) 
                SortParallel(array, getPivot, lower, pivot - 1); },
            () => { if (pivot + 1 < upper) 
                SortParallel(array, getPivot, pivot + 1, upper); });
    }
}