namespace Two_FirstTask;
using Matrix = Matrix.Matrix;

public class GradientMethod
{
    public void GradientMethodSolution(Matrix A, double[] b)
    {
        double eps = 1e-6; 
        int iteration = 0;
        
        double[] x = new double[b.Length]; 
        double[] g = Data.FunctionsGradient(A, x, b); 

        while (Data.Norm(g) > eps)
        {
            double alpha = ComputeOptimalStep(A, g);
            x = UpdateSolution(x, g, alpha);
            g = Data.FunctionsGradient(A, x, b);
            iteration++;

            Console.WriteLine($"Iteration {iteration}: Norm(g) = {Data.Norm(g):E6}");
        }
        
        Console.WriteLine("\nFinal solution:");
        for (int i = 0; i < x.Length; i++)
        {
            Console.WriteLine($"x[{i}] = {x[i]:F6}");
        }
    }
    
    private double ComputeOptimalStep(Matrix A, double[] g)
    {
        double[] Ag = A * g;
        double numerator = Data.Dot(g, g);  // g^T * g
        double denominator = Data.Dot(g, Ag);  // g^T * A * g

        if (denominator <= 0)
        {
            throw new InvalidOperationException("Denominator in step size calculation is non-positive.");
        }

        double alpha = numerator / (2 * denominator);
        Console.WriteLine($"Computed alpha: {alpha}");
        return alpha;
    }

    private double[] UpdateSolution(double[] x, double[] g, double alpha)
    {
        return Data.Sub(x, Data.Mul(alpha, g));
    }
}