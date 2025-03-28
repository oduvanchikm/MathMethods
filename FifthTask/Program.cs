using FifthTask;

Console.WriteLine("----------------------------------------------------------------------------------");
Console.WriteLine("a) x_n+1 = 2^(x_n - 1)");
Console.WriteLine("x < 1.52");
Console.WriteLine();
double[] x0ValuesA = {-1.0, 2.0, 1.15, 3.53};

foreach (var guess in x0ValuesA)
{
    SimpleIteration.Solve(guess, Functions.DerivativeA, Functions.FunctionA);
}
Console.WriteLine("----------------------------------------------------------------------------------");
Console.WriteLine();
Console.WriteLine("----------------------------------------------------------------------------------");

Console.WriteLine("b) x_n+1 = -ln(x_n)");
Console.WriteLine("x > 1");
Console.WriteLine();
double[] x0ValuesB = {-1.0, 1.0, 1.15, 1.52};

foreach (var guess in x0ValuesB)
{
    SimpleIteration.Solve(guess, Functions.DerivativeB, Functions.FunctionB);
}
Console.WriteLine("----------------------------------------------------------------------------------");
Console.WriteLine();
Console.WriteLine("----------------------------------------------------------------------------------");

Console.WriteLine("c) x_n+1 = e^(-x_n)");
Console.WriteLine("x > 0");
Console.WriteLine();
double[] x0ValuesC = {-7.0, 1.0, 1.15, 1.53};

foreach (var guess in x0ValuesC)
{
    SimpleIteration.Solve(guess, Functions.DerivativeC, Functions.FunctionC);
}
Console.WriteLine("----------------------------------------------------------------------------------");
Console.WriteLine();
Console.WriteLine("----------------------------------------------------------------------------------");

Console.WriteLine("d) x_n+1 = (x_n + e^(-x_n)) / 2");
Console.WriteLine("x > 0");
Console.WriteLine();
double[] x0ValuesD = {-700.0, 1.0, 1.15, 1.53};

foreach (var guess in x0ValuesD)
{
    SimpleIteration.Solve(guess, Functions.DerivativeD, Functions.FunctionD);
}
Console.WriteLine("----------------------------------------------------------------------------------");
Console.WriteLine();
Console.WriteLine("----------------------------------------------------------------------------------");

Console.WriteLine("e) x_n+1 = (x_n + e^(-x_n)) / 2");
Console.WriteLine("x > -ln(11 / 5) = -0.788");
Console.WriteLine();
double[] x0ValuesE = {-700.0, -0.6, 1.0, 1.15, 1.53};

foreach (var guess in x0ValuesE)
{
    SimpleIteration.Solve(guess, Functions.DerivativeE, Functions.FunctionE);
}
Console.WriteLine("----------------------------------------------------------------------------------");
Console.WriteLine();
Console.WriteLine("----------------------------------------------------------------------------------");

Console.WriteLine("f) x_n+1 = e^(2x_n) - 1");
Console.WriteLine("x < -1 / 2 * ln(2) = -0.346");
Console.WriteLine();
double[] x0ValuesF = {-700.0, -0.35, 1.0, 1.15, 1.53};

foreach (var guess in x0ValuesF)
{
    SimpleIteration.Solve(guess, Functions.DerivativeF, Functions.FunctionF);
}
Console.WriteLine("----------------------------------------------------------------------------------");
Console.WriteLine();
Console.WriteLine("----------------------------------------------------------------------------------");

Console.WriteLine("g) x_n+1 = 1 / 2 - ln(x)");
Console.WriteLine("x > 1");
Console.WriteLine();
double[] x0ValuesG = { -1.0, -0.01, 1.15, 1.53, 0.5, 0.8, 1, 1.2, 1.5, 45};

foreach (var guess in x0ValuesG)
{
    SimpleIteration.Solve(guess, Functions.DerivativeG, Functions.FunctionG);
}
Console.WriteLine("----------------------------------------------------------------------------------");
Console.WriteLine();
Console.WriteLine("----------------------------------------------------------------------------------");

Console.WriteLine("h) x_n+1 = tg(x)");
Console.WriteLine("не сходится");
double[] x0ValuesH = {-700.0, 1.0, 1.15, 1.53};

foreach (var guess in x0ValuesH)
{
    SimpleIteration.Solve(guess, Functions.DerivativeH, Functions.FunctionH);
}
Console.WriteLine("----------------------------------------------------------------------------------");