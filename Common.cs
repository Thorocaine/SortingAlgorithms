namespace SortingAlgorithms;

public static class Common
{
    public static void Swap (IList<int> array, int a, int b) =>
        (array[a], array[b]) = (array[b], array[a]);

    public static int[] RandomArray(int length)
    {
        var rnd = new Random();
        var max = length * 2;
        return Enumerable.Repeat(0,int.MaxValue)
                         .Select(_ => rnd.Next(0, max))
                         .Distinct()
                         .Take(length)
                         .ToArray();
    }
}