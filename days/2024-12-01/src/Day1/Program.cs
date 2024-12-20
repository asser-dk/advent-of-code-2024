namespace Day1;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code 2024 - Day 1");

        var (leftValues, rightValues) = GetListsFromFile();

        var totalDistance = CalculateTotalDistance(leftValues, rightValues);
        var similarity = CalculateSimilarity(leftValues, rightValues);

        Console.WriteLine($"Total distance: {totalDistance}");
        Console.WriteLine($"Similarity: {similarity}");
    }

    public static int CalculateTotalDistance(List<int> leftValues, List<int> rightValues)
    {
        leftValues.Sort();
        rightValues.Sort();

        var totalDistance = 0;
        for (var i = 0; i < leftValues.Count; i++)
        {
            totalDistance += Math.Abs(leftValues[i] - rightValues[i]);
        }

        return totalDistance;
    }

    private static (List<int> LeftValues, List<int> RightValues) GetListsFromFile()
    {
        var fileLines = File.ReadAllLines(Path.Combine("data", "input.txt"));

        var leftList = new List<int>();
        var rightList = new List<int>();

        foreach (var (leftValue, rightValue) in fileLines
                     .Select(x => x.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
                     .Select(x => (int.Parse(x[0]), int.Parse(x[1]))))
        {
            leftList.Add(leftValue);
            rightList.Add(rightValue);
        }

        leftList.Sort();
        rightList.Sort();

        return (leftList, rightList);
    }

    public static int CalculateSimilarity(List<int> listA, List<int> listB)
    {
        var occurrences = listB.GroupBy(x => x).ToLookup(x => x.Key, x => x.Count());

        var similarity = 0;
        foreach (var value in listA)
        {
            similarity += value * occurrences[value].SingleOrDefault();
        }

        return similarity;
    }
}
