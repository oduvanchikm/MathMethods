namespace ThirdTask;

public class Functions
{
    // Point a
    public static double Function1(double x)
    {
        return Math.Pow(x, 3) + 3 * Math.Pow(x, 2) - 1;
    }
    
    public static double Derivative1(double x)
    {
        double alpha = GetAlpha1(x);
        return 1 + 3 * Math.Pow(x, 2) * alpha + 6 * x * alpha;
    }
    
    public static double GetAlpha1(double x)
    {
        if (x > -3 && x <= -2.5)
            return -2.0 / 9.0;
        else if (x > -1 && x <= 0.5)
            return 2.0 / 3.0;
        else if (x > 0.5 && x <= 2)
            return -1.0 / 12.0;
        else
            throw new Exception("X is outside the acceptable range");
    }
    
    // Point b
    
    public static double Function2(double x)
    {
        return Math.Pow(x, 4) - Math.Pow(x, 3);
    }
    
    public static double Derivative2(double x)
    {
        double alpha = GetAlpha2(x);
        return 1 + 4 * Math.Pow(x, 3) * alpha - 3 * Math.Pow(x, 2) * alpha;
    }
    
    public static double GetAlpha2(double x)
    {
        if (x >= -1 && x < 0.5) 
            return 2.0 / 7.0;
        else if (x > 0.8 && x <= 2) 
            return -1.0 / 10.0;
        else
            throw new Exception("X is outside the acceptable range");
    }
    
    // Point c
    
    public static double Function3(double x)
    {
        return Math.Pow(x, 2) - 3 * x + 2;
    }
    
    public static double Derivative3(double x)
    {
        double alpha = GetAlpha3(x);
        return 1 + 2 * x * alpha - 3 * alpha;
    }
    
    public static double GetAlpha3(double x)
    {
        if (x >= 0 && x < 1.2)
            return 2.0 / 3.0;
        else if (x >= 1.8 && x <= 3)
            return -2.0 / 3.0;
        else
            throw new Exception("X is outside the acceptable range");
    }
}