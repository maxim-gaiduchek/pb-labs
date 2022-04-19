namespace CSharpProject;

public class Time : Pair
{
    // Num1 - hours, Num2 - minutes

    public Time(int num1, int num2) : base(num1, num2)
    {
    }

    public override void IncrementNum1()
    {
        Num1++;
    }

    public override void IncrementNum2()
    {
        Num2++;

        if (Num2 > 59)
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
            Num2 = 59;
        }
    }

    public override string ToString()
    {
        return $"{Num1} hours and {Num2} minutes";
    }
}