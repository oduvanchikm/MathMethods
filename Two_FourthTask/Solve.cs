namespace Two_FourthTask;
using Matrix = Matrix.Matrix;

public class Solve
{
    
    private static void Normalize(double[] v)
    {
        double norm = Math.Sqrt(v.Sum(val => val * val));
        if (norm == 0) return;
        for (int i = 0; i < v.Length; i++)
        {
            v[i] /= norm;
        }
    }

    private static double DotProduct(double[] v1, double[] v2)
    {
        double sum = 0;
        for (int i = 0; i < v1.Length; i++)
        {
            sum += v1[i] * v2[i];
        }
        
        return sum;
    }

    private static double[] MultiplyMatrixVector(Matrix A, double[] x)
    {
        int n = A.Rows;
        double[] result = new double[n];
        for (int i = 0; i < n; i++)
        {
            result[i] = 0;
            for (int j = 0; j < n; j++)
            {
                result[i] += A[i, j] * x[j];
            }
        }
        
        return result;
    }
    
    private static double PowerIteration(Matrix A)
    {
        double epsilon = 1e-10;
        int n = A.Rows;
        double[] x = new double[n];
        double[] y = new double[n];

        for (int i = 0; i < n; i++)
        {
            x[i] = 1.0;
        }

        Normalize(x);

        double lambdaOld = 0;
        int iterations = 0;

        while (true)
        {
            for (int i = 0; i < n; i++)
            {
                y[i] = 0;
                for (int j = 0; j < n; j++)
                {
                    y[i] += A[i, j] * x[j];
                }
            }

            Normalize(y);

            var lambdaNew = DotProduct(y, MultiplyMatrixVector(A, y));

            if (Math.Abs(lambdaNew - lambdaOld) < epsilon)
            {
                Console.WriteLine($"Iterations: {iterations}");
                return Math.Abs(lambdaNew);
            }

            lambdaOld = lambdaNew;
            Array.Copy(y, x, n);
            iterations++;
        }
    }
    
    public static void SolveIterative(double[] y0)
    {
        var bInverse = Data.B().Inverse();
        
        double spectralRadius = PowerIteration(bInverse);
        
        Console.WriteLine($"Spectral radius: {spectralRadius}");
        
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