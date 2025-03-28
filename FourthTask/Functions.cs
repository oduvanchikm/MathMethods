namespace FourthTask;

public class Functions
{
    // Point a
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
    
    // Point b
    // function: phi(x) = c + a * e^(-bx^2)
    public static double FunctionB(double x, double a, double b, double c)
    {
        return c + a * Math.Pow(Math.E, -b * Math.Pow(x, 2));
    }
    
    // derivative: phi'(x) = - 2 * a * b * x / e^(b * x^2)
    public static double DerivativeB(double x, double a, double b)
    {
        return (-2 * a * b * x) / Math.Pow(Math.E, b * Math.Pow(x, 2));
    }
}