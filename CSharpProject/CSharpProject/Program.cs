namespace CSharpProject;

class Program
{
    public static void Main()
    {
        var random = new Random();
        var n = random.Next(2, 6);
        var matrixCoefficients = new int[n][];
        
        for (var i = 0; i < n; i++)
        {
            matrixCoefficients[i] = new int[n];
            
            for (var j = 0; j < n; j++)
            {
                matrixCoefficients[i][j] = random.Next(0, 10);
            }
        }

        Matrix matrix1 = new(n), matrix2 = new(matrixCoefficients);

        Console.WriteLine("M1:");
        Console.WriteLine(matrix1);
        Console.WriteLine("M2:");
        Console.WriteLine(matrix2);

        var matrix3 = matrix1 + matrix2;

        Console.WriteLine("M3:");
        Console.WriteLine(matrix3);

        matrix3 *= matrix3;

        Console.WriteLine("New M3:");
        Console.WriteLine(matrix3);

        Console.WriteLine("New M3's norm:");
        Console.WriteLine(matrix3.GetNorm());
    }
}
