namespace SortingAlgorithms;

public static class MergeSort
{
    public static void Sort(int[] array) => Sort(array.AsSpan());
    
    static void Sort(Span<int> data)
    {
        var n = data.Length;
        if (n <= 1) return;
        Span<int> left = data[..(n / 2)], right = data[(n / 2)..];
        Sort(left); Sort(right);
        Merge(left.ToArray(), right.ToArray(), data);
    }

    static void Merge(int[] left, int[] right, Span<int> data)
    {
        int i = 0, j = 0, k = 0;
        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j]) data[k++] = left[i++];
            else data[k++] = right[j++];
        }
        while (i < left.Length)data[k++] = left[i++];
        while (j < right.Length) data[k++] = right[j++];
    }
}