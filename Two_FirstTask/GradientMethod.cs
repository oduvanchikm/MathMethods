namespace Two_FirstTask;
using Matrix = Matrix.Matrix;

public class GradientMethod
{
    public GradientMethod(Matrix A, double[] b)
    {
        double eps = 1e-6; 
        int iteration = 0;
        int maxIterations = 1000;
        
        double[] x = new double[b.Length]; 
        double[] g = Data.FunctionsGradient(A, x, b); 

        while (Data.Norm(g) > eps && iteration < maxIterations)
        {
            double alpha = StepSize(A, g);
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
    
    private double StepSize(Matrix A, double[] g)
    {
        double[] Ag = A * g;
        return Data.Dot(g, g) / Data.Dot(g, Ag);
    }

    private double[] UpdateSolution(double[] x, double[] g, double alpha)
    {
        return Data.Sub(x, Data.Mul(alpha, g));
    }
}