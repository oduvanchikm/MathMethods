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
        { 28, 0, 0 },
        { 0, 72, 0 },
        { 0, 0, -16 }
    });

    public static Matrix.Matrix BInverse() => new Matrix.Matrix(new double[,]
    {
        { 1.0 / 28.0, 0, 0 },
        { 0, 1.0 / 72.0, 0 },
        { 0, 0, -1.0 / 16.0 }
    });

    public static Matrix.Matrix I() => new Matrix.Matrix(new double[,]
    {
        { 1, 0, 0 },
        { 0, 1, 0 },
        { 0, 0, 1 }
    });

    public static Matrix.Matrix FindTmatrix()
    {
        return I() - BInverse() * A();
    }

    public static double[] f() => new double[] { 1, -2, 4 };
}