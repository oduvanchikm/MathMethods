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
    
    public static Matrix.Matrix ATranspose() => new Matrix.Matrix(new double[,]
    {
        { 28, -36, 164 },
        { -4, 72, -8 },
        { 16, -40, -16 }
    });

    // public static Matrix.Matrix B() => new Matrix.Matrix(new double[,]
    // {
    //     { 43464, 0, 0 },
    //     { 0, 7896, 0 },
    //     { 0, 0, 3168 }
    // });
    
    public static Matrix.Matrix B() => new Matrix.Matrix(new double[,]
    {
        { 56, 0, 0 },
        { 0, 144, 0 },
        { 0, 0, -32 }
    });
    
    public static Matrix.Matrix ATA() => new Matrix.Matrix(new double[,]
    {
        { 28976, -4016, -736 },
        { -4016, 5264, -2816 },
        { -736, -2816, 2112 }
    });
    
    public static double[] ATf() => new double[] { 732, -180, 32 };

    public static double[] f() => new double[] { 1, -2, 4 };
}