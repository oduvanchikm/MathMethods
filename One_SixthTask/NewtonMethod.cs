namespace One_SixthTask;

public class NewtonMethod
{
    public static void FindRoots()
    {
        double[] initialGuesses = { 0.5, 1.5, 2.5 };
        double eps = 1e-6;
            
        Console.WriteLine("Finding first three positive roots of (x-1)^3 * sin(πx) * (cos(2πx) - 1) = 0");
        Console.WriteLine("==============================================================================");

        foreach (double x0 in initialGuesses)
        {
            Console.WriteLine($"\nStarting with initial guess: {x0}");
                
            double x = x0;
            double f = Data.Function(x);
            int iteration = 0;
            bool converged = false;

            while (Math.Abs(f) > eps && iteration < 100)
            {
                double df = Data.Derivative(x);

                if (Math.Abs(df) < eps)
                {
                    Console.WriteLine("Warning: Derivative is too small, cannot continue");
                    break;
                }

                double xNew = x - f / df;
                iteration++;
                    
                if (Math.Abs(xNew - x) < eps)
                {
                    converged = true;
                    x = xNew;
                    break;
                }

                x = xNew;
                f = Data.Function(x);
                    
                // Console.WriteLine($"Iteration {iteration}: x = {x:F15}, f(x) = {f:E8}");
            }

            if (converged || Math.Abs(f) < eps)
            {
                Console.WriteLine($"\nFound root at x = {x:F15}");
                Console.WriteLine($"After {iteration} iterations, f(x) = {f:E8}");
            }
            else
            {
                Console.WriteLine($"\nFailed to converge after {iteration} iterations");
            }
        }
    }
}