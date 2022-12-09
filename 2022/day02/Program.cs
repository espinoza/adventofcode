string text = File.ReadAllText("input.txt").Trim();
Console.WriteLine("Advent of Code 2022 - Day 02");

var elfChoices = new string[3] {"A", "B", "C"};
var ownChoices = new string[3] {"X", "Y", "Z"};
var decrypted = new Dictionary<string, string>
{
    ["A"]="r", ["B"]="p", ["C"]="s", ["X"]="r", ["Y"]="p", ["Z"]="s"
};
var loser = new Dictionary<string, string> { {"r", "s"}, {"s", "p"}, {"p", "r"} };
var shapeScore = new Dictionary<string, int> { {"r", 1}, {"p", 2}, {"s", 3} };
var roundScore = new Dictionary<string, int>();

foreach (string elfChoice in elfChoices)
{
    foreach (string ownChoice in ownChoices)
    {
        bool draw = decrypted[ownChoice] == decrypted[elfChoice];
        bool win = loser[decrypted[ownChoice]] == decrypted[elfChoice];
        int scoreByOutcome = (draw ? 3 : 0) + (win ? 6 : 0);
        roundScore[$"{elfChoice} {ownChoice}"] = scoreByOutcome + shapeScore[decrypted[ownChoice]];
    }
}

int score = text.Split('\n').Select(s => roundScore[s]).Sum();
System.Console.WriteLine($"Part 1: {score}");