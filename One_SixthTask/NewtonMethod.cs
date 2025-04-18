namespace One_SixthTask;

public class NewtonMethod
{
    public static void CompareMethods()
    {
        double[] initialGuesses = { 0.5, 1.8, 2.7 };
        int[] precisions = { 3, 4, 5, 6 };
        int multiplicity = 3; // Кратность корня для (x-1)^3

        Console.WriteLine("Comparison of standard and modified Newton methods");
        Console.WriteLine("==========================================================");
        Console.WriteLine("The equation: (x-1)^3 * sin(πx) * (cos(2πx) - 1) = 0");
        Console.WriteLine("Modification: σ = -p where p = 3 (multiplicity of the root)\n");

        // Шапка таблицы
        Console.WriteLine("| Init. guess | Accuracy (ε)  | Method         | Root            | Iterations | f(x)        |");
        Console.WriteLine("|-------------|---------------|----------------|-----------------|------------|-------------|");

        foreach (double x0 in initialGuesses)
        {
            foreach (int n in precisions)
            {
                double eps = Math.Pow(10, -n);

                var (root1, iter1, f1) = FindRootStandard(x0, eps);
                Console.WriteLine($"| {x0,-11:F1} | 1e-{n,-10} | Newton         | {root1,-15:F12} | {iter1,-10} | {f1,-11:E3} |");

                var (root2, iter2, f2) = FindRootModified(x0, eps, multiplicity);
                Console.WriteLine($"| {x0,-11:F1} | 1e-{n,-10} | Modif Newton   | {root2,-15:F12} | {iter2,-10} | {f2,-11:E3} |");
                
                Console.WriteLine("|-------------|---------------|----------------|-----------------|------------|-------------|");
            }
        }
    }

    private static (double root, int iterations, double fValue) FindRootStandard(double x0, double eps)
    {
        double x = x0;
        double f = Data.Function(x);
        int iteration = 0;

        while (Math.Abs(f) > eps)
        {
            double df = Data.Derivative(x);
            if (Math.Abs(df) < eps) break;

            x = x - f / df;
            f = Data.Function(x);
            iteration++;
        }

        return (x, iteration, f);
    }

    private static (double root, int iterations, double fValue) FindRootModified(double x0, double eps, int p)
    {
        double x = x0;
        double f = Data.Function(x);
        int iteration = 0;

        while (Math.Abs(f) > eps)
        {
            double df = Data.Derivative(x);
            if (Math.Abs(df) < eps) break;

            x = x - p * (f / df);
            f = Data.Function(x);
            iteration++;
        }

        return (x, iteration, f);
    }
}