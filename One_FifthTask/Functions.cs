namespace One_FifthTask;

public class Functions
{
    // TODO: point a
    // function: phi(x) = 2^(x - 1)
    public static double FunctionA(double x)
    {
        return Math.Pow(2, x - 1);
    }
    
    // derivative: phi'(x) = ln2 * 2^(x - 1)
    public static double DerivativeA(double x)
    {
        return Math.Log(2) * Math.Pow(2, x - 1);
    }
    
    // TODO: point b
    // function: phi(x) = -ln(x)
    public static double FunctionB(double x)
    {
        return -Math.Log(x);
    }
    
    // derivative: phi'(x) = -1 / x
    public static double DerivativeB(double x)
    {
        return -1.0 / x; 
    }
    
    // TODO: point c
    // function: phi(x) = e^(-x)
    public static double FunctionC(double x)
    {
        return Math.Pow(Math.E, -x);
    }
    
    // derivative: phi'(x) = -e^x
    public static double DerivativeC(double x)
    {
        return -Math.Pow(Math.E, -x);
    }
    
    // TODO: point d
    // function: phi(x) = (x + e^(-x)) / 2
    public static double FunctionD(double x)
    {
        return (x + Math.Pow(Math.E, -x)) / 2.0;
    }
    
    // derivative: phi'(x) = (1 - e^(-x)) / 2
    public static double DerivativeD(double x)
    {
        return (1 - Math.Pow(Math.E, -x)) / 2.0;
    }
    
    // TODO: point e
    // function: phi(x) = (3x + 5e^(-x)) / 8
    public static double FunctionE(double x)
    {
        return (3 * x + 5 * Math.Pow(Math.E, -x)) / 8.0;
    }
    
    // derivative: phi'(x) = (3 - 5e^(-x)) / 8
    public static double DerivativeE(double x)
    {
        return (3 - 5 * Math.Pow(Math.E, -x)) / 8.0;
    }
    
    // TODO: point f
    // function: phi(x) = e^(2x) - 1
    public static double FunctionF(double x)
    {
        return Math.Pow(Math.E, 2 * x) - 1;
    }
    
    // derivative: phi'(x) = 2e^(2x)
    public static double DerivativeF(double x)
    {
        return 2 * Math.Pow(Math.E, 2 * x);
    }
    
    // TODO: point g
    // function: phi(x) = 1 / 2 - ln(x)
    public static double FunctionG(double x)
    {
        return 1.0 / 2.0 - Math.Log(x);
    }
    
    // derivative: phi'(x) = -1 / x
    public static double DerivativeG(double x)
    {
        if (x != 0)
            return -1.0 / x;
        else
            throw new Exception("x is zero");
    }
    
    // TODO: point h
    // function: phi(x) = tg(x)
    public static double FunctionH(double x)
    {
        return Math.Tan(x);
    }
    
    // derivative: phi'(x) = 1 / cos^2 (x)
    public static double DerivativeH(double x)
    {
        return 1.0 / Math.Pow(Math.Cos(x), 2);
    }
}