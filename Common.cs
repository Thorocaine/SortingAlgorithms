namespace SortingAlgorithms;

public static class Common
{
    public static void Swap (IList<int> array, int a, int b) =>
        (array[a], array[b]) = (array[b], array[a]);

    public static int[] RandomArray(int length)
    {
        var rnd = new Random();
        var max = length * 2;
        return Enumerable.Range(0, length).Select(_ => rnd.Next(0, max)).ToArray();
    }
}