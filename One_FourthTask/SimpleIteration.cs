namespace One_FourthTask;

public class SimpleIteration
{
    private static bool CheckConvergence(double x, double a, double b, Func<double, double, double, double> derivative)
    {
        return Math.Abs(derivative(x, a, b)) < 1;
    }

    public static void Solve(double x0, double a, double b, double c,
        Func<double, double, double, double, double> function,
        Func<double, double, double, double> derivative)
    {
        Console.WriteLine($"x0 = {x0}, a = {a}, b = {b}, c = {c}");
        double epsilon = 1e-6;
        double x = x0;
        double xNext = function(x, a, b, c);
        int iterations = 0;

        if (!CheckConvergence(x, a, b, derivative))
        {
            Console.WriteLine("The method may not converge for x = {0}, since |F'(x)| >= 1", x);
            return;
        }

        while (Math.Abs(xNext - x) > epsilon)
        {
            x = xNext;
            xNext = function(x, a, b, c);
            iterations++;
        }

        Console.WriteLine("Root found: {0}, in {1} iterations", xNext, iterations);
    }
}