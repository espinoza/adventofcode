string text = File.ReadAllText("input.txt");
Console.WriteLine("Advent of Code 2022 - Day 01");
Console.WriteLine($"Part 1: {GetTopCalories(text, 1).First()}");
Console.WriteLine($"Part 2: {GetTopCalories(text, 3).Sum()}");

static int[] GetTopCalories(string text, int numberOfTopElves)
{
    string[] inventories = text.Trim().Split("\n\n");
    int[] topCalories = new int[numberOfTopElves];
    foreach (string inventory in inventories)
    {
        int currentCalories = inventory.Split('\n').Select(int.Parse).Sum();
        int minCaloriesInTop = topCalories.Min();
        if (currentCalories > minCaloriesInTop)
            topCalories[Array.IndexOf(topCalories, minCaloriesInTop)] = currentCalories;
    }
    return topCalories;
}