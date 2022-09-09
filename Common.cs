namespace SortingAlgorithms;

public static class Common
{
    public static void Swap (IList<int> array, int a, int b) =>
        (array[a], array[b]) = (array[b], array[a]);
}