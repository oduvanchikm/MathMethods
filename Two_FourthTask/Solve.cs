namespace Two_FourthTask;
using Matrix = Matrix.Matrix;

public class Solve
{
    public static void SolveIterative(double[] y0)
    {
        var bInverse = Data.B().Inverse();
        
        double tolerance = 1e-6;
        int iteration = 0;
        
        double[] y = y0;
        double error;

        do
        {
            double[] residual = Matrix.Minus(Data.A() * y, Data.f());
            double[] delta = -1.0 / 2.0 * bInverse * residual;
            double[] newY = Matrix.Plus(y, delta);
            
            error = Norm(Matrix.Minus(newY, y));
            
            y = newY;
            iteration++;

            Console.WriteLine($"Iteration {iteration}: error = {error}");
            
        } while (error >= tolerance);

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