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

    public static Matrix FunctionsGradient(Matrix A, double x, double[] b) => 2 * (A * x - b);
}