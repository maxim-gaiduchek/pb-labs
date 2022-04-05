namespace CSharpProject;

public class Formula
{
    private double[] _coefficients;

    public Formula(double a3, double a2, double a1, double a0)
    {
        _coefficients = new[] {a3, a2, a1, a0};
    }

    public double GetValue(double x)
    {
        // return _coefficients.Select((t, i) => t * Math.Pow(x, i)).Sum();
        double result = 0;

        for (var i = 0; i < _coefficients.Length; i++)
        {
            result += _coefficients[i] * Math.Pow(x, i);
        }

        return result;
    }

    public override string ToString()
    {
        return string.Join(" + ", _coefficients.Select((d, i) => (d < 0 ? $"({d})" : d.ToString()) + " * x^" + i));
    }
}