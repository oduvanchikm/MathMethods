namespace FifthTask;

public class SimpleIteration
{
    private static bool CheckConvergence(double x, Func<double, double> derivative)
    {
        return Math.Abs(derivative(x)) < 1;
    }
    
    public static void Solve(double x0, Func<double, double> derivative, Func<double, double> function)
    {
        Console.WriteLine($"x0 = {x0}");
        double epsilon = 1e-6;
        double x = x0;
        double xNext = function(x);
        int iterations = 0;
        int maxIterations = 1000;
        
        if (!CheckConvergence(x, derivative))
        {
            Console.WriteLine("The method may not converge for x = {0}, since |F'(x)| = {1} >= 1", x, Math.Abs(derivative(x)));
            return;
        }

        while (Math.Abs(xNext - x) > epsilon)
        {
            x = xNext;
            xNext = function(x);
            
            if (double.IsNaN(xNext))
            {
                Console.WriteLine("The method may not converge");
                return;
            }
            
            iterations++;
        }

        Console.WriteLine("Root found: {0}, in {1} iterations", xNext, iterations);
    }
}