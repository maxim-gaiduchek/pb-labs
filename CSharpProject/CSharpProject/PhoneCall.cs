namespace CSharpProject;

[Serializable]
public class PhoneCall
{
    public PhoneCall(string phoneNumber, string start, string end)
    {
        PhoneNumber = phoneNumber;
        Start = start;
        End = end;
    }

    private string PhoneNumber { get; set; }
    private string Start { get; set; }
    private string End { get; set; }

    public TimeOnly GetStartAsTime()
    {
        return TimeOnly.Parse(Start);
    }

    public override string ToString()
    {
        return $"PhoneCall=[{PhoneNumber}, {Start}, {End}]";
    }
}