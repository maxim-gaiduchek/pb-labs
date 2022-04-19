namespace CSharpProject;

class Program
{
    public static void Main()
    {
        var random = new Random();
        
        var n = random.Next(2, 10);
        var sum = new Money(0, 0);

        for (var i = 0; i < n; i++)
        {
            var time = new Time(random.Next(0, 8), random.Next(0, 60));
            var money = new Money(random.Next(0, 10), random.Next(0, 10));

            Console.WriteLine("Time: " + time);
            Console.WriteLine("Money: " + money);
            Console.WriteLine("Sum: " + sum);
            Console.WriteLine();

            while (time.IsNotZero())
            {
                var temp = new Money(money);
                
                while (temp.IsNotZero())
                {
                    sum.IncrementNum2();
                    temp.DecrementNum2();
                }
                time.DecrementNum2();
            }
        }

        Console.WriteLine("Sum: " + sum);
    }
}