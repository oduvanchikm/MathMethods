namespace Matrix;

public class Matrix
{
    private double[,] data;

    public Matrix(double[,] data)
    {
        this.data = data;
    }
    
    public static Matrix operator *(Matrix A, double x)
    {
        int rows = A.data.GetLength(0);
        int cols = A.data.GetLength(1);
        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = A.data[i, j] * x;
            }
        }

        return new Matrix(result);
    }
    
    public static Matrix operator *(double x, Matrix A)
    {
        return A * x;
    }

    public static double[] operator *(Matrix A, double[] b)
    {
        int rows = A.data.GetLength(0);
        int cols = A.data.GetLength(1);
        
        if (cols != b.Length) throw new ArgumentException("Несовпадение размеров матрицы и вектора");

        double[] result = new double[rows];

        for (int i = 0; i < rows; i++)
        {
            double sum = 0;
            for (int j = 0; j < cols; j++)
            {
                sum += A.data[i, j] * b[j];
            }
            result[i] = sum;
        }

        return result;
    }

    public static Matrix operator -(Matrix A, double[] b)
    {
        int rows = A.data.GetLength(0);
        int cols = A.data.GetLength(1);
        
        if (b.Length != cols)
            throw new ArgumentException("Длина вектора должна совпадать с количеством столбцов матрицы");

        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = A.data[i, j] - b[j];
            }
        }

        return new Matrix(result);
    }
}