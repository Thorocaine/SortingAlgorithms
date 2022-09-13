using System.Collections.Concurrent;

namespace SortingAlgorithms;

public static class QuickSort
{
    public enum Pivot
    {
        First,
        Middle,
        Last,
        TwentyFive,
        SeventyFive
    }

    public static void Sort(int[] array, Pivot pivot) => Sort(array, GetPivotFunc(pivot), 0, array.Length - 1);

    public static void SortParallel(int[] array, Pivot pivot) =>
        SortParallel(array, GetPivotFunc(pivot), 0, array.Length - 1);

    static void Sort(int[] array, GetPivot getPivot, int lower, int upper)
    {
        if (lower >= upper) return;
        var pivot = Partition(array, getPivot, lower, upper);
        if (pivot > 1) Sort(array, getPivot, lower, pivot - 1);
        if (pivot + 1 < upper) Sort(array, getPivot, pivot + 1, upper);
    }

    static void SortParallel(int[] array, GetPivot getPivot, int lower, int upper)
    {
        if (lower >= upper) return;
        if (upper - lower <= 1000) { Sort(array, getPivot, lower, upper); return; }
        var pivot = Partition(array, getPivot, lower, upper);
        Parallel.Invoke(
            () => { if (pivot > 1) SortParallel(array, getPivot, lower, pivot - 1); },
            () => { if (pivot + 1 < upper) SortParallel(array, getPivot, pivot + 1, upper); });
    }

    static int Partition(int[] array, GetPivot getPivot, int lower, int upper)
    {
        var pivot = getPivot(array, lower, upper);
        while (true)
        {
            while (array[lower] < pivot) lower++;
            while (array[upper] > pivot) upper--;
            if (lower < upper) (array[upper], array[lower]) = (array[lower], array[upper]);
            else return upper;
        }
    }

    delegate int GetPivot(int[] array, int lower, int upper);

    static GetPivot GetPivotFunc(Pivot pivot) =>
        pivot switch
        {
            Pivot.First => (a, l, u) => a[l],
            Pivot.Last => (a, l, u) => a[u],
            Pivot.TwentyFive => (a, l, u) => a[l + (u - l) / 4],
            Pivot.SeventyFive => (a, l, u) => a[l + (u - l) * 3 / 4],
            _ => (a, l, u) => a[l + (u - l) / 2],
        };
}