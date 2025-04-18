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

    public double this[int row, int col]
    {
        get => data[row, col];
        set => data[row, col] = value;
    }
    
    public static Matrix operator *(Matrix A, Matrix B)
    {
        int rowsA = A.data.GetLength(0);
        int colsA = A.data.GetLength(1);
        int rowsB = B.data.GetLength(0);
        int colsB = B.data.GetLength(1);

        double[,] result = new double[rowsA, colsB];

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                double sum = 0;
                for (int k = 0; k < colsA; k++)
                {
                    sum += A.data[i, k] * B.data[k, j];
                }
                result[i, j] = sum;
            }
        }

        return new Matrix(result);
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
    
    public static Matrix operator -(Matrix A, Matrix B)
    {
        int rows = A.data.GetLength(0);
        int cols = A.data.GetLength(1);

        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = A.data[i, j] - B.data[i, j];
            }
        }

        return new Matrix(result);
    }
    
    public static double[] Minus(double[] a, double[] b)
    {
        int rows = a.GetLength(0);

        double[] result = new double[rows];

        for (int i = 0; i < rows; i++)
        {
            result[i] = a[i] - b[i];
        }

        return result;
    }
    
    public static double[] Plus(double[] a, double[] b)
    {
        int rows = a.GetLength(0);

        double[] result = new double[rows];

        for (int i = 0; i < rows; i++)
        {
            result[i] = a[i] + b[i];
        }

        return result;
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
    
    public static double[] MultDigitArray(double a, double[] b)
    {
        double[] result = new double[b.Length];

        for (int i = 0; i < b.Length; i++)
        {
            result[i] = b[i] * a;
        }

        return result;
    }
    
    public static double[] SolveTriangular(Matrix L, double[] b)
    {
        double[] x = new double[b.Length];
        for (int i = 0; i < b.Length; i++)
        {
            double sum = 0;
            for (int j = 0; j < i; j++)
            {
                sum += L.data[i,j] * x[j];
            }
            x[i] = (b[i] - sum) / L.data[i,i];
        }
        return x;
    }
}