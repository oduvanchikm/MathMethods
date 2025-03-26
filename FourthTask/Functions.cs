namespace FourthTask;

public class Functions
{
    // function: phi(x) = c + a sin^2 (x) + b cos^2 (x)
    public static double FunctionA(double x, double a, double b, double c)
    {
        return c + a * Math.Pow(Math.Sin(x), 2) + b * Math.Pow(Math.Cos(x), 2);
    }
    
    // derivative: phi'(x) = (a - b) sin(2x)
    public static double DerivativeA(double x, double a, double b)
    {
        return (a - b) * Math.Sin(2 * x);
    }
}