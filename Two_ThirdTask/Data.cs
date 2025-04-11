namespace Two_ThirdTask;

public class Data
{
    public static double[] g(Matrix.Matrix A, double[] b, double[] x)
    {
        double[] Ax_b = Sub(Matrix.Matrix.Transpose(A) * (A * x), Matrix.Matrix.Transpose(A) * b);
        return Mul(2, Ax_b);
    }

    public static double[] Sub(double[] a, double[] b)
    {
        if (a.Length != b.Length)
            throw new ArgumentException("Vectors must be of the same length");

        double[] result = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = a[i] - b[i];
        }
        return result;
    }

    public static double[] Mul(double scalar, double[] vector)
    {
        double[] result = new double[vector.Length];
        for (int i = 0; i < vector.Length; i++)
        {
            result[i] = scalar * vector[i];
        }
        return result;
    }

    public static double Norm(double[] vector)
    {
        double sum = 0;
        for (int i = 0; i < vector.Length; i++)
        {
            sum += vector[i] * vector[i];
        }
        return Math.Sqrt(sum);
    }

    public static double Dot(double[] a, double[] b)
    {
        if (a.Length != b.Length)
            throw new ArgumentException("Vectors must be of the same length");

        double result = 0;
        for (int i = 0; i < a.Length; i++)
        {
            result += a[i] * b[i];
        }
        return result;
    }
}