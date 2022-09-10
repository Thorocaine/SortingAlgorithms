namespace SortingAlgorithms;

public static class ShellSort
{
    static int CalculateInterval(int n)
    {
        var h = 1;
        while (h < n / 3) h = 3 * h + 1;
        return h;
    }

    static int NextInterval(int h) => (h - 1) / 3;

    public static void Sort(int[] array)
    {
        var n = array.Length;
        for (var h = CalculateInterval(n); h > 0; h = NextInterval(h))
            for (var i = h; i < n; i++)
                for (var j = i; j > (h - 1) && array[j] < array[j - h]; j -= h)
                    if (array[j] >= array[j - h]) break;
                    else Common.Swap(array, j, j - h);
    }               
}