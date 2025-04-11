using Two_ThirdTask;

Matrix.Matrix A = new Matrix.Matrix(new double[,]
{
    { 1, 2 },
    { 3, 4 },
    { 5, 6 }
});

double[] b = new double[] { 5, 11, 17 };
double[] initialGuess = new double[] { 0, 0 };

Console.WriteLine("Gradient Method Solution:");
GradientMethod.GradientMethodSolution(A, b, initialGuess);