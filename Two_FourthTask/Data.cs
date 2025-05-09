using System.Numerics;

namespace Two_FourthTask;

public class Data
{
    public static Matrix.Matrix A() => new Matrix.Matrix(new double[,]
    {
        { 28, -4, 16 },
        { -36, 72, -40 },
        { 164, -8, -16 }
    });

    public static Matrix.Matrix B() => new Matrix.Matrix(new double[,]
    {
        { 28, -4, 16 },
        { 0, 72, -40 },
        { 0, 0, -16 }
    });

    public static double[] f() => new double[] { 1, -2, 4 };
}