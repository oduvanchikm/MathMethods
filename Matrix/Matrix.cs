namespace Matrix;

public class Matrix
{
    private double[,] data;
    public int Rows { get; }
    public int Cols { get; }

    public Matrix(double[,] data)
    {
        this.data = data;
        Rows = data.GetLength(0);
        Cols = data.GetLength(1);
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
        
        if (cols != b.Length) throw new ArgumentException("Difference in the size of the matrix and vector");

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
            throw new ArgumentException("Difference in the size of the matrix and vector");

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
    
    public static Matrix Transpose(Matrix matrix)
    {
        double[,] result = new double[matrix.Cols, matrix.Rows];
        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Cols; j++)
            {
                result[j, i] = matrix.data[i, j];
            }
        }
        return new Matrix(result);
    }
}