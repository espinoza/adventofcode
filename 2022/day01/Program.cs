string input = File.ReadAllText("input.txt");
string[] elvesInventories = input.Split(new string[]{"\n\n"}, StringSplitOptions.None);
int maxCalories = elvesInventories.Max(GetTotalCalories);
System.Console.WriteLine(maxCalories);

static int GetTotalCalories(string elfInventory)
{
    int[] calories = elfInventory.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    return calories.Aggregate(0, (cal1, cal2) => cal1 + cal2);
}