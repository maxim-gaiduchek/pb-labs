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
        
        Console.WriteLine("After processing:");
        ReadFromFileToConsole(sr);

        sr.Close();
    }

    private static void WriteToFileFromConsole(StreamWriter sw)
    {
        Console.WriteLine("Enter text:");
        
        while (true)
        {
            var line = Console.ReadLine();

            if (line != null && !line.Trim().Equals(""))
            {
                sw.WriteLine(line);
            }
            else
            {
                break;
            }
        }
    }

    private static void ReadFromFileToConsole(StreamReader sr)
    {
        Console.WriteLine(sr.ReadToEnd());
    }

    private static string? CountDigitsAndReturnText(StreamReader sr)
    {
        var text = sr.ReadToEnd().Split("\r\n");
        
        for (var i = 1; i <= text.Length; i++)
        {
            if (i % 2 == 0) continue;
            
            var line = text[i - 1];
            var count = 0;

            foreach (var ch in line)
            {
                if (ch is >= '0' and <= '9')
                {
                    count++;
                }
            }

            text[i - 1] = line + " " + count;
        }

        return Strings.Join(text, "\r\n");
    }
}