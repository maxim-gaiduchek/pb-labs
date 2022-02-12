using System.Runtime.Serialization.Formatters.Binary;

namespace CSharpProject;

internal static class Program
{
    public static void Main()
    {
        const string inputPath = "input.txt";
        const string dayOutputPath = "dayOutput.txt";
        const string nightOutputPath = "nightOutput.txt";
        TimeOnly dayStarts = new(6, 0), nightStarts = new(20, 0);

        var phoneCalls = GetInputPhoneCalls(inputPath);

        OutputPhoneCalls(phoneCalls, "Input calls:");
        OutputPhoneCalls(phoneCalls.FindAll(call => call.GetStartAsTime().IsBetween(dayStarts, nightStarts)),
            "Input day calls:");
        OutputPhoneCalls(phoneCalls.FindAll(call => call.GetStartAsTime().IsBetween(nightStarts, dayStarts)),
            "Input night calls:");

        WritePhoneCallsToFile(phoneCalls.FindAll(call => call.GetStartAsTime().IsBetween(dayStarts, nightStarts)),
            dayOutputPath);
        WritePhoneCallsToFile(phoneCalls.FindAll(call => call.GetStartAsTime().IsBetween(nightStarts, dayStarts)),
            nightOutputPath);

        var fileDayPhoneCalls = DeserializePhoneCallsFromFile(dayOutputPath);
        var fileNightPhoneCalls = DeserializePhoneCallsFromFile(nightOutputPath);
        
        OutputPhoneCalls(fileDayPhoneCalls, "File day calls:");
        OutputPhoneCalls(fileNightPhoneCalls, "File night calls:");
    }

    private static List<PhoneCall> GetInputPhoneCalls(string inputPath)
    {
        var phoneCalls = new List<PhoneCall>();
        var file = File.OpenText(inputPath);

        while (!file.EndOfStream)
        {
            var line = file.ReadLine();

            if (line == null) continue;

            var data = line.Split(" ");

            phoneCalls.Add(new PhoneCall(data[0], data[1], data[2]));
        }
        
        file.Close();

        return phoneCalls;
    }

    private static void OutputPhoneCalls(List<PhoneCall> phoneCalls, string prompt)
    {
        Console.WriteLine(prompt);

        foreach (var phoneCall in phoneCalls)
        {
            Console.WriteLine(phoneCall);
        }

        Console.WriteLine();
    }

    private static void WritePhoneCallsToFile(List<PhoneCall> phoneCalls, string outputPath)
    {
        var stream = File.Open(outputPath, FileMode.Append);
        var binaryFormatter = new BinaryFormatter();

        foreach (var phoneCall in phoneCalls)
        {
            binaryFormatter.Serialize(stream, phoneCall);
        }

        stream.Close();
    }

    private static List<PhoneCall> DeserializePhoneCallsFromFile(string outputPath)
    {
        var phoneCalls = new List<PhoneCall>();
        var stream = File.Open(outputPath, FileMode.Open);
        var binaryFormatter = new BinaryFormatter();

        while (stream.Position < stream.Length)
        {
            phoneCalls.Add((PhoneCall) binaryFormatter.Deserialize(stream));
        }

        stream.Close();

        return phoneCalls;
    }
}