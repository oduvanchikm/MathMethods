using Two_EighthTask;

double[] epsilons = {1e-2, 1e-3, 1e-4, 1e-6};
    
Console.WriteLine("Steepest Descent Method:");
Console.WriteLine("┌──────────────┬────────────┬────────────────────────────────────────────────────────┬────────────────────────────────────────────────────┐");
Console.WriteLine("│   Epsilon    │ Iterations │                     Solution                           │                       Check                        │");
Console.WriteLine("├──────────────┼────────────┼────────────────────────────────────────────────────────┤────────────────────────────────────────────────────┤");

foreach (double eps in epsilons)
{
    Methods.SteepestDescent(eps, out var solution, out var iterations, out var check);
    string solutionStr = string.Join(", ", Array.ConvertAll(solution, x => $"{x,10:F6}"));
    string checkStr = string.Join(", ", Array.ConvertAll(check, x => $"{x,10:F6}"));
    Console.WriteLine($"│ {eps,12:e2} │ {iterations,10} │ {solutionStr,-54} │{checkStr,-52}│");
}
        
Console.WriteLine("└──────────────┴────────────┴────────────────────────────────────────────────────────┴────────────────────────────────────────────────────┘");
    
Console.WriteLine("Minimal Residual Method:");
Console.WriteLine("┌──────────────┬────────────┬────────────────────────────────────────────────────────┬────────────────────────────────────────────────────┐");
Console.WriteLine("│   Epsilon    │ Iterations │                     Solution                           │                       Check                        │");
Console.WriteLine("├──────────────┼────────────┼────────────────────────────────────────────────────────┤────────────────────────────────────────────────────┤");

foreach (double eps in epsilons)
{
    Methods.MinimalResidual(eps, out var solution, out var iterations, out var check);
    string solutionStr = string.Join(", ", Array.ConvertAll(solution, x => $"{x,10:F6}"));
    string checkStr = string.Join(", ", Array.ConvertAll(check, x => $"{x,10:F6}"));
    Console.WriteLine($"│ {eps,12:e2} │ {iterations,10} │ {solutionStr,-54} │{checkStr,-52}│");
}
        
Console.WriteLine("└──────────────┴────────────┴────────────────────────────────────────────────────────┴────────────────────────────────────────────────────┘");
