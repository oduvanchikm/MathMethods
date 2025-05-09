namespace Two_FourthTask;
using Matrix = Matrix.Matrix;

public class Solve
{
    private static bool CheckConvergence(Matrix A, Matrix BInverse)
    {
        Matrix T = Matrix.Identity(A.Rows) - 1.0 / 2.0 * BInverse * A;
        double spectralRadius = T.SpectralRadius();
        Console.WriteLine($"Spectral radius: {spectralRadius}");
        return spectralRadius < 1.0;
    }

    public static void SolveIterative(Matrix A, Matrix B, double[] f, double[] y0)
    {
        
        Matrix bInverse = B.Inverse();
        if (!CheckConvergence(A, bInverse))
        {
            Console.WriteLine("Warning: Spectral radius >= 1, convergence not guaranteed!");
        }
        
        double tolerance = 1e-6;
        int maxIterations = 1000;
        int iteration = 0;
        double[] y = (double[])y0.Clone();
        double error;

        do
        {
            double[] residual = Matrix.Minus(A * y, f);
            double[] delta = -0.5 * bInverse * residual;
            double[] newY = Matrix.Plus(y, delta);
            error = Norm(Matrix.Minus(newY, y));
            y = newY;
            iteration++;

            Console.WriteLine($"Iteration {iteration}: error = {error}");

            if (iteration >= maxIterations)
            {
                Console.WriteLine("Warning: Max iterations reached!");
                break;
            }

        } while (error > tolerance);

        Console.WriteLine($"\nConverged after {iteration} iterations");
        Console.WriteLine("Solution:");
        Console.WriteLine($"y1 = {y[0]}");
        Console.WriteLine($"y2 = {y[1]}");
        Console.WriteLine($"y3 = {y[2]}");
    }

    private static double Norm(double[] vector)
    {
        double sum = 0;
        foreach (var x in vector)
        {
            sum += x * x;
        }
        return Math.Sqrt(sum);
    }
}