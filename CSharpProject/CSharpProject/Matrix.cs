namespace CSharpProject;

public class Matrix
{
    public Matrix(int n)
    {
        var random = new Random();
        var matrix = new int[n][];

        for (var i = 0; i < n; i++)
        {
            matrix[i] = new int[n];

            for (var j = 0; j < n; j++)
            {
                matrix[i][j] = random.Next(0, 10);
            }
        }

        Coefficients = matrix;
    }

    public Matrix(int[][] matrix)
    {
        Coefficients = matrix;
    }

    private int[][] Coefficients { get; }

    public int GetNorm() // m-norm, by rows
    {
        var result = 0;

        for (var i = 0; i < Coefficients.GetLength(0); i++)
        {
            var sum = Coefficients[i].Sum();

            if (i == 0 || result < sum)
            {
                result = sum;
            }
        }

        return result;
    }

    public static Matrix operator +(Matrix matrix0, Matrix matrix1)
    {
        var n = matrix0.Coefficients.GetLength(0);
        var result = new Matrix(new int[n][]);

        for (var i = 0; i < n; i++)
        {
            result.Coefficients[i] = new int[n];
            
            for (var j = 0; j < n; j++)
            {
                result.Coefficients[i][j] = matrix0.Coefficients[i][j] + matrix1.Coefficients[i][j];
            }
        }

        return result;
    }

    public static Matrix operator *(Matrix matrix0, Matrix matrix1)
    {
        var n = matrix0.Coefficients.GetLength(0);
        var result = new Matrix(new int[n][]);

        for (var i = 0; i < n; i++)
        {
            result.Coefficients[i] = new int[n];
            
            for (var j = 0; j < n; j++)
            {
                result.Coefficients[i][j] = 0;

                for (var a = 0; a < n; a++)
                {
                    result.Coefficients[i][j] += matrix0.Coefficients[i][a] * matrix1.Coefficients[a][j];
                }
            }
        }

        return result;
    }

    public override string ToString()
    {
        var result = "";
        var n = Coefficients.GetLength(0);

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                result += Coefficients[i][j] + "\t";
            }

            result += "\n";
        }

        result += "\n";

        return result;
    }
}