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
    
    public Matrix(int rows, int cols)
    {
        data = new double[rows, cols];
        Rows = rows;
        Cols = cols;
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
    
    public static void PrintArray(Matrix matrix)
    {
        int rows = matrix.data.GetLength(0);
        int cols = matrix.data.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    public Matrix Inverse()
    {
        if (Rows != Cols)
            throw new InvalidOperationException("Matrix must be square to compute inverse.");

        int n = Rows;
        double[,] result = new double[n, n];
        double[,] temp = (double[,])data.Clone();

        for (int i = 0; i < n; i++)
        {
            result[i, i] = 1;
        }

        for (int k = 0; k < n; k++)
        {
            double max = Math.Abs(temp[k, k]);
            int row = k;
            for (int i = k + 1; i < n; i++)
            {
                if (Math.Abs(temp[i, k]) > max)
                {
                    max = Math.Abs(temp[i, k]);
                    row = i;
                }
            }

            if (row != k)
            {
                for (int j = 0; j < n; j++)
                {
                    (temp[k, j], temp[row, j]) = (temp[row, j], temp[k, j]);
                    (result[k, j], result[row, j]) = (result[row, j], result[k, j]);
                }
            }

            double div = temp[k, k];
            if (div == 0)
                throw new InvalidOperationException("Matrix is singular and cannot be inverted.");

            for (int j = 0; j < n; j++)
            {
                temp[k, j] /= div;
                result[k, j] /= div;
            }

            for (int i = 0; i < n; i++)
            {
                if (i != k && temp[i, k] != 0)
                {
                    double factor = temp[i, k];
                    for (int j = 0; j < n; j++)
                    {
                        temp[i, j] -= temp[k, j] * factor;
                        result[i, j] -= result[k, j] * factor;
                    }
                }
            }
        }

        return new Matrix(result);
    }
    
    public Matrix Transpose()
    {
        Matrix result = new Matrix(Cols, Rows);
        
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                result[j, i] = this[i, j];
            }
        }
        
        return result;
    }
}