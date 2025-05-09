using Two_SecondTask;

// second task

double[][] points = new double[][]
{
    new double[] { 1, 2 },
    new double[] { 3, 4 },
    new double[] { 5, 6 },
    new double[] { 7, 8 }
};

double[] initialGuess = new double[] { 0, 0 };

Console.WriteLine("Solution with Gradient Method:");
GradientMethod.GradientMethodSolution(points, initialGuess);

double[] exactSolution = GradientMethod.ExactSolution(points);
Console.WriteLine("Solution:");
Console.WriteLine($"x = ({exactSolution[0]:F6}, {exactSolution[1]:F6})");

