using SortingAlgorithms;

var array = new[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
ShellSort.Sort(array);
foreach (var i in array)
    Console.WriteLine(i);
