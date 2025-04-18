namespace Two_ThirdTask;

public class GradientMethod
{
    public static void GradientMethodSolution(Matrix.Matrix A, double[] b, double[] initialGuess)
    {
        double[] x = (double[])initialGuess.Clone();
        
        double eps = 1e-6;
        
        int iteration = 0;
        double[] g;
        double gradientNorm;

        do
        {
            g = Data.g(A, b, x);
            double alpha = ComputeAlpha(A, g);
            gradientNorm = Data.Norm(g);

            if (gradientNorm < eps)
                break;

            x = Data.Sub(x, Data.Mul(alpha, g));
            iteration++;
            Console.WriteLine($"Iteration {iteration}: Norm(g) = {Data.Norm(g):E6}");

        } while (gradientNorm >= eps);

        Console.WriteLine("\nFinal Solution:");
        Console.WriteLine($"Iterations: {iteration}");
        Console.WriteLine($"Solution x = [{x[0]}, {x[1]}]");
        Console.WriteLine($"Gradient Norm: {gradientNorm}");
        Console.WriteLine($"Function Value: {Data.Norm(Data.Sub(A * x, b))}");
    }
    
    private static double ComputeAlpha(Matrix.Matrix A, double[] g)
    {
        double[] Ag = A * g;
        double numerator = Data.Dot(g, g);
        double denominator = 2 * Data.Dot(Ag, Ag);
        return numerator / denominator;
    }
}