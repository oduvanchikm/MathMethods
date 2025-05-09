namespace Two_FifthTask;

using Matrix = Matrix.Matrix;

public class Solve
{
    private static double[] NextIteration(double[] y)
    {
        double[] first = Matrix.Minus(Data.Asym() * y, Data.Fsym());
        double[] result = Data.BInverse() * first;
        double[] second = Matrix.MultDigitArray(-1, result);
        return Matrix.Plus(y, second);
    }
    
    private static double CalculateSpectralRadius(Matrix matrix)
    {
        double[] v = new double[matrix.Rows];
        for (int i = 0; i < v.Length; i++)
            v[i] = 1.0; 
        
        double epsilon = 1e-8;
        double lambdaOld = 1.0;
        double lambdaNew = 0.0;
        int maxIter = 1000;
        
        for (int i = 0; i < maxIter; i++)
        {
            double[] Av = matrix * v;
            lambdaNew = Norm(Av) / Norm(v);
            
            if (Math.Abs(lambdaNew - lambdaOld) < epsilon)
                break;
                
            lambdaOld = lambdaNew;
            v = Normalize(Av);
        }
        
        return lambdaNew;
    }

    public static void SolveIterative(double[] y0)
    {
        Matrix iterationMatrix = Data.I() - Data.BInverse() * Data.Asym();
        double spectralRadius = CalculateSpectralRadius(iterationMatrix);
        
        Console.WriteLine($"Spectral radius: {spectralRadius}");
        
        double tolerance = 1e-6;
        int iteration = 0;
        double[] y = y0;
        double error;
            
        do
        {
            double[] newY = NextIteration(y);
            error = Norm(Matrix.Minus(newY, y));
            y = newY;
            iteration++;
        
        } while (error >= tolerance);
        
        Console.WriteLine($"\nConverged after {iteration} iterations");
        Console.WriteLine("Final solution:");
        Console.WriteLine($"y1 = {y[0]}");
        Console.WriteLine($"y2 = {y[1]}");
        Console.WriteLine($"y3 = {y[2]}");
    }
    
    private static double Norm(double[] b) => Math.Sqrt(b.Sum(t => t * t));
    
    private static double[] Normalize(double[] v)
    {
        double norm = Norm(v);
        return v.Select(x => x / norm).ToArray();
    }
}