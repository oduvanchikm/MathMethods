namespace Two_FourthTask;

public class Solve
{
    private static double[] NextIteration(double[] y, Matrix.Matrix A, Matrix.Matrix BInverse, double[] f)
    {
        // y_{k+1} = y_k + 0.5 * B⁻¹(f - A y_k)
        double[] Ay = A * y;
        double[] residual = Matrix.Matrix.Minus(f, Ay);
        double[] BInvResidual = BInverse * residual;
        return Matrix.Matrix.Plus(y, Matrix.Matrix.MultDigitArray(0.5, BInvResidual));
    }

    public static void SolveIterative(Matrix.Matrix A, Matrix.Matrix B, double[] f, double[] y0)
    {
        double tolerance = 1e-6;
        int maxIterations = 1000;
        int iteration = 0;
        double[] y = (double[])y0.Clone();
        double error;
            
        do
        {
            double[] newY = NextIteration(y, A, Data.BInverse(), f);
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