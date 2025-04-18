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
        { -36, 72, -40 },
        { 164, -8, -16 }
    });

    public static Matrix.Matrix AInverse() => new Matrix.Matrix(new double[,]
    {
        { 23.0 / 3078.0, 1.0 / 1026.0, 31.0 / 6156.0 },
        { 223.0 / 6156.0, 8.0 / 513.0, -17.0 / 6156.0 },
        { 10.0 / 171.0, 1.0 / 456.0, -13.0 / 1368.0 }
    });
    
    public static double[] f() => new double[] { 1, -2, 4 };
}