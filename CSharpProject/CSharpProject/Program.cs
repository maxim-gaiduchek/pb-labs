using System.Runtime.Serialization.Formatters.Binary;

namespace CSharpProject;

internal static class Program
{
    public static void Main()
    {
        // init constants
        const string inputPath = "input.txt";
        const string dayOutputPath = "dayOutput.txt";
        const string nightOutputPath = "nightOutput.txt";
        TimeOnly dayStarts = new(6, 0), nightStarts = new(20, 0);

        // init input entities, serialize and deserialize them
        InitEntities(inputPath);

        var phoneCalls = DeserializePhoneCallsFromFile(inputPath);

        OutputPhoneCalls(phoneCalls, "Input calls:");
        OutputPhoneCalls(phoneCalls.FindAll(call => call.GetStartAsTime().IsBetween(dayStarts, nightStarts)),
            "Input day calls:");
        OutputPhoneCalls(phoneCalls.FindAll(call => call.GetStartAsTime().IsBetween(nightStarts, dayStarts)),
            "Input night calls:");

        // filtering day and night calls and serialize them
        WritePhoneCallsToFile(phoneCalls.FindAll(call => call.GetStartAsTime().IsBetween(dayStarts, nightStarts)),
            dayOutputPath, FileMode.Append);
        WritePhoneCallsToFile(phoneCalls.FindAll(call => call.GetStartAsTime().IsBetween(nightStarts, dayStarts)),
            nightOutputPath, FileMode.Append);

        // deserialize all day and night calls
        var fileDayPhoneCalls = DeserializePhoneCallsFromFile(dayOutputPath);
        var fileNightPhoneCalls = DeserializePhoneCallsFromFile(nightOutputPath);

        OutputPhoneCalls(fileDayPhoneCalls, "File day calls:");
        OutputPhoneCalls(fileNightPhoneCalls, "File night calls:");
    }

    private static void InitEntities(string path)
    {
        var calls = new List<PhoneCall>
        {
            new("+380999999999", "06:00", "19:59"),
            new("+380228133700", "06:00", "20:00"),
            new("+380952281337", "20:00", "06:00"),
            new("+380555555555", "03:00", "07:37"),
            new("+380555555555", "17:28", "21:28"),
            new("+380222222222", "06:00", "06:02"),
            new("+380111111111", "20:00", "02:58"),
            new("+380954194429", "20:00", "05:59")
        };

        WritePhoneCallsToFile(calls, path, FileMode.OpenOrCreate);
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

    private static void WritePhoneCallsToFile(List<PhoneCall> phoneCalls, string outputPath, FileMode fileMode)
    {
        var stream = File.Open(outputPath, fileMode);
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