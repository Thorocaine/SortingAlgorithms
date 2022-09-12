using System.Collections.Concurrent;

namespace SortingAlgorithms;

public static class QuickSort
{
    public enum Pivot { First, Middle, Last, TwentyFive, SeventyFive }

    public static void Sort(int[] array, Pivot strategy) => Sort(array, GetPivotFunc(strategy));

    delegate int GetPivot(Span<int> array);

    static int Partition(Span<int> array, GetPivot getPivot)
    {
        var pivot = getPivot(array);
        int left = 0, right = array.Length - 1;
        while (true) 
        {
            while (array[left] < pivot) left++;
            while (array[right] > pivot) right--;
            if (left < right)
            {
                if (array[left] == array[right]) return right;
                (array[left], array[right]) = (array[right], array[left]);
            }
            else return right;
        }
    }


    static void Sort(Span<int> array, GetPivot getPivot)
    {
        if (array.Length <= 1) return;
        var pi = Partition(array, getPivot);
        Sort(array[..pi], getPivot);
        Sort(array[(pi + 1)..], getPivot);
    }

    static GetPivot GetPivotFunc(Pivot pivot) =>
        pivot switch
        {
            Pivot.First => (a) => a[0],
            Pivot.Last => (a) => a[^1],
            Pivot.TwentyFive => (a) => a[(a.Length-1) / 4], 
            Pivot.SeventyFive => (a) => a[(a.Length-1) * 3 / 4],
            _ => (a) => a[(a.Length-1) / 2],
        };

    public static IEnumerable<int> LazyQuickSort(this IEnumerable<int> list)
    {
        if (!list.Skip(1).Any()) return list;
        var pivot = list.First();
        var left = list.Skip(1).Where(x => x < pivot).LazyQuickSort();
        var right = list.Skip(1).Where(x => x >= pivot).LazyQuickSort();
        return left.Concat(new[] {pivot}).Concat(right);
    }
}