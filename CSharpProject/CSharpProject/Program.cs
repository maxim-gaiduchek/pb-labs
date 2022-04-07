namespace CSharpProject;

class Node
{
    public Node(char value)
    {
        Value = value;
    }

    public char Value { get; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }
}

class Program
{
    public static void Main()
    {
        var root = new Node((char) new Random().Next(33, 128));

        GenerateTree(root);

        while (true)
        {
            var input = Console.ReadLine();
            
            if (input is null or "stop") break;
            
            Console.WriteLine(CountValues(root, input[0]));
        }
    }

    private static void GenerateTree(Node root)
    {
        var random = new Random();

        for (var i = 0; i < random.Next(128, 256); i++)
        {
            AddValue(root, (char) random.Next(33, 128));
        }
    }

    private static void AddValue(Node root, char value)
    {
        if (value < root.Value)
        {
            if (root.Left != null)
            {
                AddValue(root.Left, value);
            }
            else
            {
                root.Left = new Node(value);
            }
        }
        else
        {
            if (root.Right != null)
            {
                AddValue(root.Right, value);
            }
            else
            {
                root.Right = new Node(value);
            }
        }
    }

    private static int CountValues(Node? root, char value)
    {
        if (root == null) return 0;
        return (root.Value == value ? 1 : 0) + CountValues(root.Left, value) + CountValues(root.Right, value);
    }
}