namespace Two_FifthTask;

using Matrix = Matrix.Matrix;

public class Solve
{
    private static double[] NextIteration(double[] y)
    {
        double[] first = Matrix.Minus(Data.Asym() * y, Data.Fsym());
        double[] result = Data.BInverse() * first;
        double[] second = Matrix.MultDigitArray(-1, result);
        return Matrix.Plus(y, second);
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
                return lambdaNew;
            }

            lambdaOld = lambdaNew;
            Array.Copy(y, x, n);
            iterations++;
        }
    }

    public static void SolveIterative(double[] y0)
    {
        Matrix iterationMatrix = Data.I() - Data.BInverse() * Data.Asym();
        double spectralRadius = PowerIteration(iterationMatrix);
        
        Console.WriteLine($"Spectral radius: {spectralRadius}");
        
        double tolerance = 1e-6;
        int iteration = 0;
        double[] y = y0;
        double error;
            
        do
        {
            double[] newY = NextIteration(y);
            error = Norm(Matrix.Minus(newY, y));
            y = newY;
            iteration++;
        
        } while (error >= tolerance);
        
        Console.WriteLine($"\nConverged after {iteration} iterations");
        Console.WriteLine("Final solution:");
        Console.WriteLine($"y1 = {y[0]}");
        Console.WriteLine($"y2 = {y[1]}");
        Console.WriteLine($"y3 = {y[2]}");
    }
    
    private static double Norm(double[] b) => Math.Sqrt(b.Sum(t => t * t));
    
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
}