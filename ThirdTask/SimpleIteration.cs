namespace ThirdTask;

public class SimpleIteration
{
    private static double IterationFunction(double x, Func<double, double> function, Func<double, double> getAlpha)
    {
        double alpha = getAlpha(x);
        return x + alpha * function(x);
    }
    
    public static void Solve(double x0, Func<double, double> derivative, Func<double, double> function, Func<double, double> getAlpha = null)
    {
        double epsilon = 1e-6;
        double xPrev = x0;
        double xNext = IterationFunction(xPrev, getAlpha, function);
        int iterations = 0;

        while (Math.Abs(xNext - xPrev) > epsilon)
        {
            if (Math.Abs(derivative(xPrev)) >= 1)
            {
                Console.WriteLine("The method does not converge for x = {0}, since |F'(x)| = {1} >= 1", xPrev, Math.Abs(derivative(xPrev)));
                return;
            }

            xPrev = xNext;
            xNext = IterationFunction(xPrev, getAlpha, function);
            iterations++;
        }

        Console.WriteLine("Root found: {0}, in {1} iterations", xNext, iterations);
    }
}