namespace Two_EighthTask;

public class Data
{
    public static Matrix.Matrix A() => new Matrix.Matrix(new double[,]
    {
        { 2.8, 2.1, -1.3, 0.3 },
        { -1.4, 4.5, -7.7, 1.3 },
        { 0.6, 2.1, -5.8, 2.4 },
        { 3.5, -6.5, 3.2, -7.9 }
    });

    public static double[] b => new double[] { 1, 1, 1, 1 };

    public static Matrix.Matrix AInverse()
    {
        return A().Inverse();
    }
}