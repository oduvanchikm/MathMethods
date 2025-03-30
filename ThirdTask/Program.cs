using ThirdTask;

double[] initialGuesses1 = { -2.5, -0.5, 0.6 };

Console.WriteLine("Result of task 3a:");
foreach (var guess in initialGuesses1)
{
    SimpleIteration.Solve(guess, Functions.Derivative1, Functions.Function1, Functions.GetAlpha1);
}

double[] initialGuesses2 = { -0.6, 0.9 };

Console.WriteLine();
Console.WriteLine("Result of task 3b:");
foreach (var guess in initialGuesses2)
{
    SimpleIteration.Solve(guess, Functions.Derivative2, Functions.Function2, Functions.GetAlpha2);
}

double[] initialGuesses3 = { 0.9, 1.9 };

Console.WriteLine();
Console.WriteLine("Result of task 3c:");
foreach (var guess in initialGuesses3)
{
    SimpleIteration.Solve(guess, Functions.Derivative3, Functions.Function3, Functions.GetAlpha3);
}