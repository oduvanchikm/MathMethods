using FourthTask;

Console.WriteLine("----------------------------------------------------------------------------------");
Console.WriteLine("a) phi(x) = c + a sin^2(x) + b cos^2(x)");
Console.WriteLine();

double[] x0ValuesA = {-1.0, 2.0, 1.15, 3.53};


double[,] parameters = {
    {2.0, 3.0, 1.0},  // |a - b| = 1 (не сходится)
    {2.0, 1.5, 1.0},  // |a - b| = 0.5 (сходится)
    {3.0, 2.5, 2.0},  // |a - b| = 0.5 (сходится)
    {1.0, 0.0, 0.5},  // |a - b| = 1 (не сходится)
    {0.5, 0.2, 3.0},  // |a - b| = 0.3 (сходится)
};

for (int i = 0; i < parameters.GetLength(0); i++) 
{
    double a = parameters[i, 0];
    double b = parameters[i, 1];
    double c = parameters[i, 2];

    if (Math.Abs(a - b) >= 1)
    {
        Console.WriteLine($"For a = {a}, b = {b}: Condition |a - b| < 1 is not satisfied, method may not converge.");
    }
    else
    {
        Console.WriteLine($"For a = {a}, b = {b}: Condition |a - b| < 1 is satisfied.");
    }

    foreach (var guess in x0ValuesA)
    {
        SimpleIteration.Solve(guess, a, b, c, Functions.FunctionA);
    }

    Console.WriteLine("----------------------------------------------------------------------------------");
}