namespace One_ThirdTask;

public static class SimpleIteration
{
    private static double IterationFunction(double x, Func<double, double> function, Func<double, double> getAlpha)
    {
        double alpha = getAlpha(x);
        return x + alpha * function(x);
    }

    private static bool CheckConvince(double x,Func<double, double> derivative)
    {
        return Math.Abs(derivative(x)) >= 1;
    }
    
    public static void Solve(double x0, Func<double, double> derivative, Func<double, double> function, Func<double, double> getAlpha = null)
    {
        Console.WriteLine($"x0 = {x0}");
        double epsilon = 1e-6;
        double xPrev = x0;
        double xNext = IterationFunction(xPrev, function, getAlpha);
        int iterations = 0;
        
        if (CheckConvince(xPrev, derivative))
        {
            Console.WriteLine("The method does not converge for x = {0}, since |F'(x)| = {1} >= 1", xPrev, Math.Abs(derivative(xPrev)));
            return;
        }

        while (Math.Abs(xNext - xPrev) > epsilon)
        {
            xPrev = xNext;
            xNext = IterationFunction(xPrev, getAlpha, function);
            iterations++;
        }

        Console.WriteLine("Root found: {0}, in {1} iterations", xNext, iterations);
    }
}