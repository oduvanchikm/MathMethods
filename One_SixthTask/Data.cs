namespace One_SixthTask;

public class Data
{
    public static double Function(double x) => 
        Math.Pow(x - 1, 3) * Math.Sin(Math.PI * x) * (Math.Cos(2 * Math.PI * x) - 1);

    public static double Derivative(double x) =>
        3 * Math.Pow(x - 1, 2) * Math.Sin(Math.PI * x) * (Math.Cos(2 * Math.PI * x) - 1) +
        Math.Pow(x - 1, 3) * Math.PI * Math.Cos(Math.PI * x) * (Math.Cos(2 * Math.PI * x) - 1) +
        Math.Pow(x - 1, 3) * Math.Sin(Math.PI * x) * (-2 * Math.PI * Math.Sin(2 * Math.PI * x));
}