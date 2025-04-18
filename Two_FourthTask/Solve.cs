namespace Two_FourthTask;

public class Solve
{
    private static double[] NextIteration(double[] y, Matrix.Matrix AInverse, double[] f)
    {
        // y_{k+1} = 0.5 * y_k + 0.5 * A^{-1} * f
        double[] first = Matrix.Matrix.MultDigitArray(1.0 / 2.0, y);
        double[] second = 1.0 / 2.0 * AInverse * f;
        return Matrix.Matrix.Plus(first, second);
    }

    public static void SolveIterative(Matrix.Matrix A, double[] f, double[] y0)
    {
        double tolerance = 1e-6;
        int maxIterations = 1000;
        int iteration = 0;
        double[] y = (double[])y0.Clone();
        double error;
            
        do
        {
            double[] newY = NextIteration(y, Data.AInverse(), f);
            error = Norm(Matrix.Matrix.Minus(newY, y));
            y = newY;
            iteration++;
        } while (error > tolerance);

        Console.WriteLine($"\nConverged after {iteration} iterations");
        Console.WriteLine("Final solution:");
        Console.WriteLine($"y1 = {y[0]}");
        Console.WriteLine($"y2 = {y[1]}");
        Console.WriteLine($"y3 = {y[2]}");
            
        double[] residual = Matrix.Matrix.Minus(f, A * y);
        Console.WriteLine($"Final residual norm: {Norm(residual)}");
    }
    
    private static double Norm(double[] b)
    {
        double sum = 0;
        for (int i = 0; i < b.Length; ++i)
        {
            sum += b[i] * b[i];
        }

        return Math.Sqrt(sum);
    }
}