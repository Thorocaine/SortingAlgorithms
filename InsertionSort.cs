namespace SortingAlgorithms;

public static class InsertionSort
{
    public static void Sort(int[] array)
    {
        for (var i = 1; i < array.Length; i++)
        {
            int t = array[i], j = i - 1;
            for (;j >= 0 && array[j] > t; j--)
                array[j + 1] = array[j];
            array[j + 1] = t;
        }
    }
}