namespace CSharpProject;

public abstract class Pair
{
    protected Pair(int num1, int num2)
    {
        Num1 = num1;
        Num2 = num2;
    }

    protected int Num1 { get; set; }
    protected int Num2 { get; set; }

    public bool IsNotZero()
    {
        return Num1 != 0 || Num2 != 0;
    }

    public abstract void IncrementNum1();

    public abstract void IncrementNum2();

    public abstract void DecrementNum1();

    public abstract void DecrementNum2();
}