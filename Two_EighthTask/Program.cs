using Two_EighthTask;

double[] epsilons = {1e-2, 1e-3, 1e-4, 1e-6};
    
Console.WriteLine("Метод скорейшего спуска:");
foreach (double eps in epsilons)
{
    var (solution, iterations) = Methods.SteepestDescent(Data.A(), Data.b, eps);
    Console.WriteLine($"Точность {eps}: {iterations} итераций");
    Console.WriteLine($"Решение: [{string.Join(", ", solution)}]");
}
    
Console.WriteLine("\nМетод минимальных невязок:");
foreach (double eps in epsilons)
{
    var (solution, iterations) = Methods.MinimalResidual(Data.A(), Data.b, eps);
    Console.WriteLine($"Точность {eps}: {iterations} итераций");
    Console.WriteLine($"Решение: [{string.Join(", ", solution)}]");
}