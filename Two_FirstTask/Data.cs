namespace Two_FirstTask;
using Matrix = Matrix.Matrix;

public class Data
{
    public static Matrix A = new Matrix(new double[,]
        {
            { 4, -1, 0, -1, 0, 0 },
            { -1, 4, -1, 0, -1, 0 },
            { 0, -1, 4, 0, 0, -1 },
            { -1, 0, 0, 4, -1, 0 },
            { 0, -1, 0, -1, 4, -1 },
            { 0, 0, -1, 0, -1, 4 }
        }
    );

    public static double[] b = { 0, 5, 0, 6, -2, 6 };

    public static double[] FunctionsGradient(Matrix A, double[] x, double[] b) => Mul(2, Sub(A * x, b));
    
    public static double[] Sub(double[] a, double[] b)
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
    
    public static double[] Mul(double b, double[] a)
    {
        int lengthA = a.Length;
    
        double[] result = new double[lengthA];
    
        for (int i = 0; i < lengthA; i++)
        {
            result[i] = a[i] * b;
        }
    
        return result;
    }

    public static double Norm(double[] b)
    {
        double sum = 0;

        for (int i = 0; i < b.Length; ++i)
        {
            sum += b[i] * b[i];
        }

        return Math.Sqrt(sum);
    }

    public static double Dot(double[] a, double[] b)
    {
        double result = 0;
        for (int i = 0; i < a.Length; ++i)
        {
            result += a[i] * b[i];
        }
        return result;
    }
}