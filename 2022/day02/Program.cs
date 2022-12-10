string text = File.ReadAllText("input.txt").Trim();
Console.WriteLine("Advent of Code 2022 - Day 02");

var shapeScores = new Dictionary<string, int> { {"A", 1}, {"B", 2}, {"C", 3} };
var elfChoices = new string[3] {"A", "B", "C"};
var ownChoices = new string[3] {"X", "Y", "Z"};

var choicesOpponents = new Dictionary<string, OpponentRole>
{
    { "A", new OpponentRole {Loser="C", Tie="A", Winner="B"} },
    { "B", new OpponentRole {Loser="A", Tie="B", Winner="C"} },
    { "C", new OpponentRole {Loser="B", Tie="C", Winner="A"} },
};


// Part 1

var roundScores1 = new Dictionary<string, int>();
var decryptedChoice = new Dictionary<string, string> { ["X"]="A", ["Y"]="B", ["Z"]="C" };

foreach (string elfChoice in elfChoices)
{
    foreach (string ownChoice in ownChoices)
    {
        bool tie = choicesOpponents[decryptedChoice[ownChoice]].Tie == elfChoice;
        bool win = choicesOpponents[decryptedChoice[ownChoice]].Loser == elfChoice;
        int scoreByOutcome = (tie ? 3 : 0) + (win ? 6 : 0);
        roundScores1[$"{elfChoice} {ownChoice}"] = scoreByOutcome + shapeScores[decryptedChoice[ownChoice]];
    }
}

int score = text.Split('\n').Select(s => roundScores1[s]).Sum();
System.Console.WriteLine($"Part 1: {score}");


// Part 2

var roundScores2 = new Dictionary<string, int>();
var decryptedOwnRole = new Dictionary<string, Func<OpponentRole, string>>
{
    ["X"] = (x=>x.Loser), ["Y"] = (x=>x.Tie), ["Z"] = (x=>x.Winner)
};

foreach (string elfChoice in elfChoices)
{
    foreach (string ownChoice in ownChoices)
    {
        bool tie = ownChoice == "Y";
        bool win = ownChoice == "Z";
        int scoreByOutcome = (tie ? 3 : 0) + (win ? 6 : 0);
        string ownShape = decryptedOwnRole[ownChoice](choicesOpponents[elfChoice]);
        roundScores2[$"{elfChoice} {ownChoice}"] = scoreByOutcome + shapeScores[ownShape];
    }
}

score = text.Split('\n').Select(s => roundScores2[s]).Sum();
System.Console.WriteLine($"Part 2: {score}");


class OpponentRole
{
    public string? Loser {get; set;}
    public string? Tie {get; set;}
    public string? Winner {get; set;}
}