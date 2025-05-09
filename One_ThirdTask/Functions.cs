namespace One_ThirdTask;

public class Functions
{
    // Point a
    public static double Function1(double x)
    {
        return Math.Pow(x, 3) + 3 * Math.Pow(x, 2) - 1;
    }

    public static double Derivative1(double x)
    {
        var alpha = GetAlpha1(x);
        return 1 + 3 * Math.Pow(x, 2) * alpha + 6 * x * alpha;
    }

    private static double GetAlpha1(double x)
    {
        return x switch
        {
            > -3 and <= -2.5 => -2.0 / 9.0,
            > -1 and <= 0.5 => 2.0 / 3.0,
            > 0.5 and <= 2 => -1.0 / 12.0,
            _ => throw new Exception("X is outside the acceptable range")
        };
    }

    // Point b
    public static double Function2(double x)
    {
        return x is >= -1.0 and <= 0.5
            ? Math.Pow(Math.Pow(x, 4) - Math.Pow(x, 3), 2.0 / 3.0) 
            : Math.Pow(x, 4) - Math.Pow(x, 3);
    }

    public static double Derivative2(double x)
    {
        double alpha = GetAlpha2(x);
        return x is >= -1.0 and <= 0.5
            ? 1 + alpha * 2.0 / 3.0 * Math.Pow(Math.Pow(x, 4) - Math.Pow(x, 3), -1.0 / 3.0) * 
            (4 * Math.Pow(x, 3) - 3 * Math.Pow(x, 2))
            : 1 + alpha * (4 * Math.Pow(x, 3) - 3 * Math.Pow(x, 2));
    }

    public static double GetAlpha2(double x)
    {
        return x switch
        {
            >= -1.0 and <= 0.5 => 0.269983,
            >= 0.8 and <= 2.0 => -0.05,
            _ => throw new Exception($"x = {x} is outside [-1.0, 2.0]")
        };
    }

    // Point c
    public static double Function3(double x)
    {
        return Math.Pow(x, 2) - 3 * x + 2;
    }

    public static double Derivative3(double x)
    {
        var alpha = GetAlpha3(x);
        return 1 + 2 * x * alpha - 3 * alpha;
    }

    private static double GetAlpha3(double x)
    {
        return x switch
        {
            >= 0 and < 1.2 => 1.0 / 3.0,
            >= 1.8 and <= 3 => -1.0 / 3.0,
            _ => throw new Exception("X is outside the acceptable range")
        };
    }
}