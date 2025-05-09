namespace Two_EighthTask;

public class Methods
{
    public static (double[] solution, int iterations) SteepestDescent(Matrix.Matrix A, double[] b, double epsilon, int maxIterations = 10000)
    {
        int n = b.Length;
        double[] x = new double[n];
        int iterations = 0;
        
        for (iterations = 0; iterations < maxIterations; iterations++)
        {
            double[] residual = Matrix.Matrix.Minus(b, A * x);
            
            if (Norm(residual) < epsilon)
                break;
                
            double[] Ar = A * residual;
            double alpha = DotProduct(residual, residual) / DotProduct(residual, Ar);
            
            for (int i = 0; i < n; i++)
            {
                x[i] += alpha * residual[i];
            }
        }
        
        return (x, iterations);
    }

    public static (double[] solution, int iterations) MinimalResidual(Matrix.Matrix A, double[] b, double epsilon, int maxIterations = 10000)
    {
        int n = b.Length;
        double[] x = new double[n];
        int iterations = 0;
        
        for (iterations = 0; iterations < maxIterations; iterations++)
        {
            double[] residual = Matrix.Matrix.Minus(b, A * x); 
            
            if (Norm(residual) < epsilon)
                break;
                
            double[] Ar = A * residual;
            double alpha = DotProduct(residual, Ar) / DotProduct(Ar, Ar);
            
            for (int i = 0; i < n; i++)
            {
                x[i] += alpha * residual[i];
            }
        }
        
        return (x, iterations);
    }

    private static double DotProduct(double[] a, double[] b)
    {
        double result = 0;
        for (int i = 0; i < a.Length; i++)
        {
            result += a[i] * b[i];
        }
        return result;
    }

    private static double Norm(double[] vector)
    {
        return Math.Sqrt(DotProduct(vector, vector));
    }
}