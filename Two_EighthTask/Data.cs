using matrix = Matrix.Matrix;

namespace Two_EighthTask;

public class Data
{
    public static matrix A() => new matrix(new double[,]
    {
        { 2.8, 2.1, -1.3, 0.3 },
        { -1.4, 4.5, -7.7, 1.3 },
        { 0.6, 2.1, -5.8, 2.4 },
        { 3.5, -6.5, 3.2, -7.9 }
    });

    public static matrix ATA() => A().Transpose() * A();
    
    public static double[] ATb() => A().Transpose() * b();

    public static double[] b() => new double[] { 1, 1, 1, 1 };

    public static matrix ATranspose => A().Transpose();
}