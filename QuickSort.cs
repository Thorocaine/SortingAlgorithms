using System.Collections.Concurrent;

namespace SortingAlgorithms;

public static class QuickSort
{
    public enum Pivot
    {
        First,
        Middle,
        Last,
    } //, Last, MedianOfThree, Random } 

    delegate int Partition(Span<int> array); 

    public static void Sort(int[] array, Pivot pivot)
    {
        quickSort(array, GetPartition(pivot));
    }

    static int PartitionMiddle(Span<int> array)
    {
        int left = 0; int right = array.Length - 1;
        int i = left, j = right;

        int tmp;

        var pivot = array[(left + right) / 2];


        while (i <= j)
        {
            while (array[i] < pivot)

                i++;

            while (array[j] > pivot)

                j--;

            if (i <= j)
            {
                tmp = array[i];

                array[i] = array[j];

                array[j] = tmp;

                i++;

                j--;
            }
        }

        


        return i;
    }

    static int PartitionLast(Span<int> array)
    {
        int start = 0; int end = array.Length - 1;
            int pivot = array[end]; // pivot element  
            int i = (start - 1);  
  
            for (int j = start; j <= end - 1; j++)  
            {  
                // If current element is smaller than the pivot  
                if (array[j] < pivot)  
                {  
                    i++; // increment index of smaller element  
                    (array[i], array[j]) = (array[j], array[i]);
                }  
            }  
            (array[i+1], array[end]) = (array[end], array[i+1]);
            return (i + 1);  
        
    }
    
    static void quickSort(Span<int> array, Partition partition)
    {
        var index = partition(array);
        if (index > 1)
        {
            var leftArray = array[..index];
            quickSort(leftArray, partition);
        }

        if (index < array.Length - 1)
        {
            var rightArray = array[(index+1)..];
            quickSort(rightArray, partition);
        }
    }

    public static IEnumerable<int> LazyQuickSort(this IEnumerable<int> list)
    {
        if (!list.Skip(1).Any()) return list;
        var pivot = list.First();
        var left = list.Skip(1).Where(x => x < pivot).LazyQuickSort();
        var right = list.Skip(1).Where(x => x >= pivot).LazyQuickSort();
        return left.Concat(new[] {pivot}).Concat(right);
    }

    static Partition GetPartition(Pivot pivot)
    {
        return pivot switch
        {
            Pivot.Middle => PartitionMiddle,
            Pivot.Last => PartitionLast,
            _ => PartitionMiddle,
        };
    }
}