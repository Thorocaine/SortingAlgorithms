namespace SortingAlgorithms;

public static class SelectionSort
{
    public static void Sort(int[] array)
    {
        var n = array.Length;
        for (int i = 0, m = 0; i < n - 1; i++, m = i)
        {
            for (var j = i + 1; j < n; j++)
                if (array[j] < array[m])
                    m = j;
            if (m != i) Common.Swap(array, i, m);
        }
    }
}