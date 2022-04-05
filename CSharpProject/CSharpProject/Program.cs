namespace CSharpProject;

public static class Program
{
    public static void Main()
    {
        var formulas = CreateFormulas();
        
        OutputArray(formulas);

        var (a, b, eps) = InputRange();
        var min = FindMinFormula(formulas, a, b, eps);

        Console.WriteLine($"Min(x) = {min}");
    }

    private static Formula[] CreateFormulas()
    {
        var random = new Random();
        var length = random.Next(2, 10);
        var formulas = new Formula[length];

        for (var i = 0; i < length; i++)
        {
            formulas[i] = new Formula(
                random.Next(-10, 10) * random.NextDouble(),
                random.Next(-10, 10) * random.NextDouble(),
                random.Next(-10, 10) * random.NextDouble(),
                random.Next(-10, 10) * random.NextDouble()
            );
        }

        return formulas;
    }

    private static void OutputArray(Formula[] formulas)
    {
        Console.WriteLine("Formulas:");
        foreach (var formula in formulas)
        {
            Console.WriteLine(formula);
        }

        Console.WriteLine();
    }

    private static (double, double, double) InputRange()
    {
        Console.Write("Input a: ");
        var a = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Input b: ");
        var b = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Input eps: ");
        var eps = Convert.ToDouble(Console.ReadLine());
        
        return (a, b, eps);
    }

    private static Formula FindMinFormula(Formula[] formulas, double a, double b, double eps)
    {
        Formula min = null;
        double minValue = 0;
        
        foreach (var formula in formulas)
        {
            for (var x = a; x <= b; x += eps)
            {
                var value = formula.GetValue(x);
                
                if (min == null)
                {
                    min = formula;
                    minValue = value;
                    
                    Console.WriteLine($"f({x}) = {formula} = {value}");
                }
                else
                {
                    if (minValue <= value) continue;
                    
                    min = formula;
                    minValue = value;
                    
                    Console.WriteLine($"f({x}) = {formula} = {value}");
                }
            }
        }

        return min;
    }
}