namespace Squer.Workshops.PropertyBasedTesting.Production.Model;

public record struct PositiveTimeSpan
{
    public static PositiveTimeSpan FromSeconds(ulong seconds) => new(seconds);

    private PositiveTimeSpan(ulong seconds)
    {
        Value = TimeSpan.FromSeconds(seconds);
    }

    public TimeSpan Value { get; }

    public override string ToString() => Value.ToString();
}