namespace Two_FifthTask;

using Matrix = Matrix.Matrix;

public class Data
{
    public static Matrix A() => new Matrix(new double[,]
    {
        { -1, 2, 5 },
        { 3, -1, 1 },
        { 4, -3, 2 }
    });

    public static Matrix AT() => new Matrix(new double[,]
    {
        { -1, 3, 4 },
        { 2, -1, -3 },
        { 5, 1, 2 }
    });

    public static Matrix I() => new Matrix(new double[,]
    {
        { 1, 0, 0 },
        { 0, 1, 0 },
        { 0, 0, 1 }
    });

    public static Matrix Asym() => AT() * A();
    
    public static double[] Fsym() => AT() * f();

    public static Matrix B() => new Matrix(new double[,]
    {
        { 1.5 * Asym()[0, 0], 0, 0 },
        { 0, 1.5 * Asym()[1, 1], 0 },
        { 0, 0, 1.5 * Asym()[2, 2] },
    });

    public static Matrix BInverse() => B().Inverse();

    public static double[] f() => new double[] { 1, 0, 3 };
}