using Microsoft.VisualBasic;

namespace CSharpProject;

internal static class Program
{
    public static void Main()
    {
        const string path = "file.txt";
        
        // writing to file
        var sw = File.Exists(path) ? File.AppendText(path) : File.CreateText(path);

        WriteToFileFromConsole(sw);

        sw.Close();

        // reading from file to console
        var sr = File.OpenText(path);
        
        Console.WriteLine("Before processing:");
        ReadFromFileToConsole(sr);

        sr.Close();

        // process file
        sr = File.OpenText(path);
        
        var text = CountDigitsAndReturnText(sr);
        sr.Close();
        
        sw = File.CreateText(path);
        
        sw.Write(text);
        sw.Close();

        // reading from file to console
        sr = File.OpenText(path);
        
        Console.WriteLine("After parsing:");
        ReadFromFileToConsole(sr);

        sr.Close();
    }

    private static void WriteToFileFromConsole(StreamWriter sw)
    {
        string? line;
        
        Console.WriteLine("Enter text:");

        do
        {
            line = Console.ReadLine();

            if (line != null && (line.Length == 0 || line.Trim()[0] != 25))
            {
                sw.WriteLine(line);
            }
        } while (line != null && (line.Length == 0 || line.Trim()[0] != 25));
    }

    private static void ReadFromFileToConsole(StreamReader sr)
    {
        Console.WriteLine(sr.ReadToEnd());
    }

    private static string? CountDigitsAndReturnText(StreamReader sr)
    {
        var text = sr.ReadToEnd().Split("\r\n");
        
        for (var i = 0; i < text.Length; i++)
        {
            if (i % 2 == 1) continue;
            
            var count = 0;

            foreach (var ch in text[i])
            {
                if (ch is >= '0' and <= '9')
                {
                    count++;
                }
            }

            text[i] += " " + count;
        }

        return Strings.Join(text, "\r\n");
    }
}