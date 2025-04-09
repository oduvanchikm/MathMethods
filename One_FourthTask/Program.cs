using One_FourthTask;

Console.WriteLine("----------------------------------------------------------------------------------");
Console.WriteLine("a) phi(x) = c + a sin^2(x) + b cos^2(x)");
Console.WriteLine();

double[] x0ValuesA = {-1.0, 2.0, 1.15, 3.53};


double[,] parametersA = {
    {7.0, 3.0, 1.0},  // |a - b| = 1 (не сходится)
    {2.0, 1.5, 1.0},  // |a - b| = 0.5 (сходится)
    {3.0, 2.5, 2.0},  // |a - b| = 0.5 (сходится)
    {99999.0, 0.0, 0.5},  // |a - b| = 1 (не сходится)
    {0.5, 0.2, 3.0},  // |a - b| = 0.3 (сходится)
};

for (int i = 0; i < parametersA.GetLength(0); i++) 
{
    double a = parametersA[i, 0];
    double b = parametersA[i, 1];
    double c = parametersA[i, 2];

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
        SimpleIteration.Solve(guess, a, b, c, Functions.FunctionA, Functions.DerivativeA);
    }

    Console.WriteLine("----------------------------------------------------------------------------------");
}

Console.WriteLine();
Console.WriteLine("----------------------------------------------------------------------------------");
Console.WriteLine("b) phi(x) = c + a * e^(-bx^2)");
Console.WriteLine();

double[] x0ValuesB = {-0.5, 0.0, 0.5, 1.0, 1.5};


double[,] parametersB = {
    {1.0, 0.5, 0.0},  // 
    {2.0, 1.0, 1.0},  // 
    {0.5, 0.1, 0.5},  // 
    {3.0, 0.2, 2.0},  // 
    {1.0, 2.0, 1.0}   // 
};

for (int i = 0; i < parametersB.GetLength(0); i++) 
{
    double a = parametersB[i, 0];
    double b = parametersB[i, 1];
    double c = parametersB[i, 2];

    if (Math.Abs((a * Math.Sqrt(2 * b)) / Math.E) >= 1)
    {
        Console.WriteLine($"For a = {a}, b = {b}: Condition is not satisfied, method may not converge.");
    }
    else
    {
        Console.WriteLine($"For a = {a}, b = {b}: Condition is satisfied.");
    }

    foreach (var guess in x0ValuesB)
    {
        SimpleIteration.Solve(guess, a, b, c, Functions.FunctionB, Functions.DerivativeB);
    }

    Console.WriteLine("----------------------------------------------------------------------------------");
}