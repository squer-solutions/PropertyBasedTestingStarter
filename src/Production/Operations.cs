namespace Squer.Workshops.PropertyBasedTesting.Production;

public static class Operations
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static Control[] Merge(Control controlA, Control controlB)
    {
        return new Control[] { controlA };
    }
}

public record Control(DateTime Start, PositiveTimeSpan Duration);

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