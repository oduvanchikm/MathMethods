namespace Two_SecondTask;

public class GradientMethod
{
    public static void GradientMethodSolution(double[][] points, double[] initialGuess)
    {
        double eps = 1e-6;
        int iteration = 0;
        double[] x = (double[])initialGuess.Clone();
        int n = points[0].Length;
        double alpha = 1.0 / points.Length;
        double prevValue = ObjectiveFunction(points, x);

        while (true)
        {
            double[] g = CalculateGradient(points, x, n);

            if (Norm(g) < eps) break;
            
            double[] newX = UpdateSolution(x, g, alpha, n);
            double newValue = ObjectiveFunction(points, newX);
            
            if (newValue < prevValue)
            {
                x = newX;
                prevValue = newValue;
            }
            else
            {
                alpha *= 0.5;
                continue;
            }

            iteration++;
            Console.WriteLine($"Iteration {iteration}: Norm(g) = {Norm(g):E6}, alpha = {alpha:E6}");
        }

        Console.WriteLine("\nFinal solution:");
        for (int i = 0; i < x.Length; i++)
        {
            Console.WriteLine($"x[{i}] = {x[i]:F6}");
        }
    }

    private static double ObjectiveFunction(double[][] points, double[] x)
    {
        double sum = 0;
        foreach (var point in points)
        {
            double dist = 0;
            for (int i = 0; i < x.Length; i++)
            {
                dist += (x[i] - point[i]) * (x[i] - point[i]);
            }
            sum += dist;
        }
        return sum;
    }

    private static double[] CalculateGradient(double[][] points, double[] x, int n)
    {
        double[] g = new double[n];
        for (int i = 0; i < n; i++)
        {
            g[i] = 0;
        }

        foreach (var point in points)
        {
            for (int i = 0; i < n; i++)
            {
                g[i] += 2 * (x[i] - point[i]);
            }
        }

        return g;
    }

    private static double[] UpdateSolution(double[] x, double[] g, double alpha, int n)
    {
        double[] result = new double[n];
        for (int i = 0; i < n; i++)
        {
            result[i] = x[i] - alpha * g[i];
        }

        return result;
    }

    public static double[] ExactSolution(double[][] points)
    {
        int n = points[0].Length;
        double[] result = new double[n];

        for (int i = 0; i < n; i++)
        {
            result[i] = 0;
            foreach (var point in points)
            {
                result[i] += point[i];
            }

            result[i] /= points.Length;
        }

        return result;
    }

    private static double Norm(double[] b)
    {
        double sum = 0;
        for (int i = 0; i < b.Length; ++i)
        {
            sum += b[i] * b[i];
        }

        return Math.Sqrt(sum);
    }
}