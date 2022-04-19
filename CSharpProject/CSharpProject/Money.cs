namespace CSharpProject;

public class Money : Pair
{
    // Num1 - hryvna, Num2 - kopiyka

    public Money(int num1, int num2) : base(num1, num2)
    {
    }

    public Money(Money other) : base(other.Num1, other.Num2)
    {
    }

    public override void IncrementNum1()
    {
        Num1++;
    }

    public override void IncrementNum2()
    {
        Num2++;

        if (Num2 > 99)
        {
            IncrementNum1();
            Num2 = 0;
        }
    }

    public override void DecrementNum1()
    {
        Num1--;
    }

    public override void DecrementNum2()
    {
        Num2--;

        if (Num2 < 0)
        {
            DecrementNum1();
            Num2 = 99;
        }
    }

    public override string ToString()
    {
        return $"{Num1} hryvnas and {Num2} kopiykas";
    }
}