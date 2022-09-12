using System.Collections.Concurrent;

namespace SortingAlgorithms;

public static class QuickSort
{
    public enum Pivot { First, Last }

    public static void Sort(int[] array, Pivot strategy) => Sort(array, GetPartition(strategy), 0, array.Length - 1);

    delegate int Partition(int[] array, int low, int high);

    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    static int PartitionLast(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = (low - 1);
        for (int j = low; j <= high - 1; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }
        Swap(arr, i + 1, high);
        return (i + 1);
    }

    static int PartitionFirst(int[] arr, int left, int right)
    {
        int pivot = arr[left];
        while (true) 
        {

            while (arr[left] < pivot) 
            {
                left++;
            }

            while (arr[right] > pivot)
            {
                right--;
            }

            if (left < right)
            {
                if (arr[left] == arr[right]) return right;

                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;


            }
            else 
            {
                return right;
            }
        }
    }


    static void Sort(int[] arr, Partition partition, int low, int high)
    {
        if (low < high)
        {
            // pi is partitioning index, arr[p]
            // is now at right place 
            int pi = partition(arr, low, high);

            // Separately sort elements before
            // partition and after partition
            Sort(arr, partition, low, pi - 1);
            Sort(arr, partition, pi + 1, high);
        }
    }


    static Partition GetPartition(Pivot pivot) =>
        pivot switch
        {
            Pivot.First => PartitionFirst,
            _ => PartitionLast,           
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