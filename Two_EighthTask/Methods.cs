using matrix = Matrix.Matrix;

namespace Two_EighthTask;

public class Methods
{
    public static void SteepestDescent(double epsilon, out double[] solution, out int iterations, out double[] check)
    {
        matrix A = Data.ATA();
        double[] b = Data.ATb();
        
        iterations = 0;
        double[] x = new double[b.Length]; 
        double[] g = FunctionsGradient(A, x, b); 

        while (Norm(g) > epsilon)
        {
            double alpha = ComputeOptimalStep(A, g);
            x = UpdateSolution(x, g, alpha);
            g = FunctionsGradient(A, x, b);
            iterations++;
        }
        
        solution = x;
        check = Data.A() * solution;
    }

    public static void MinimalResidual(double epsilon, out double[] solution, out int iterations, out double[] check)
    {
        matrix A = Data.ATA();
        double[] b = Data.ATb();
        
        iterations = 0;
        double[] x = new double[b.Length];

        var residual = Sub(b, A * x);

        while (Norm(residual) > epsilon)
        {
            double alpha = ComputeOptimalStep(residual, A * residual);
            x = solution = Add(x, Mul(alpha, residual));
            residual = Sub(b, A * solution);
            iterations++;
        }
        
        solution = x;
        check = Data.A() * solution;
    }
    
    private static double[] Add(double[] a, double[] b)
    {
        if (a.Length != b.Length)
            throw new ArgumentException("Vectors must be of the same length");
    
        double[] result = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = a[i] + b[i];
        }
        return result;
    }
    
    private static double[] UpdateSolution(double[] x, double[] g, double alpha)
    {
        return Sub(x, Mul(alpha, g));
    }
    
    private static double[] FunctionsGradient(matrix A, double[] x, double[] b) => Mul(2, Sub(A * x, b));
    
    private static double[] Sub(double[] a, double[] b)
    {
        int lengthA = a.Length;
        int lengthB = b.Length;
        
        if (lengthB != lengthA)
            throw new ArgumentException("Difference in the size of the vector and vector");
    
        double[] result = new double[lengthA];
    
        for (int i = 0; i < lengthA; i++)
        {
            result[i] = a[i] - b[i];
        }
    
        return result;
    }
    
    private static double[] Mul(double b, double[] a)
    {
        int lengthA = a.Length;
    
        double[] result = new double[lengthA];
    
        for (int i = 0; i < lengthA; i++)
        {
            result[i] = a[i] * b;
        }
    
        return result;
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
    
    private static double ComputeOptimalStep(matrix A, double[] g)
    {
        double[] Ag = A * g;
        double numerator = DotProduct(g, g);  
        double denominator = DotProduct(g, Ag);  

        if (denominator <= 0)
        {
            throw new InvalidOperationException("Denominator in step size calculation is non-positive.");
        }

        double alpha = numerator / (2 * denominator);
        return alpha;
    }
    
    private static double ComputeOptimalStep(double[] x, double[] y)
    {
        double numerator = DotProduct(x, y);  
        double denominator = DotProduct(y, y);  

        if (denominator <= 0)
        {
            throw new InvalidOperationException("Denominator in step size calculation is non-positive.");
        }

        double alpha = numerator / denominator;
        return alpha;
    }

    private static double Norm(double[] vector)
    {
        return Math.Sqrt(DotProduct(vector, vector));
    }
}