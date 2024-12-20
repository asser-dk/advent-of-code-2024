namespace Day1.Test;

public class ProgramTest
{
    [Test]
    public async Task Part1Test()
    {
        var listA = new List<int> { 3, 4, 2, 1, 3, 3, };
        var listB = new List<int> { 4, 3, 5, 3, 9, 3 };

        var difference = Program.CalculateTotalDistance(listA, listB);

        await Assert.That(difference).Is.EqualTo(11);
    }

    [Test]
    public async Task Part2Test()
    {
        var listA = new List<int> { 3, 4, 2, 1, 3, 3, };
        var listB = new List<int> { 4, 3, 5, 3, 9, 3 };

        var similarity = Program.CalculateSimilarity(listA, listB);

        await Assert.That(similarity).Is.EqualTo(31);
    }
}
