using FsCheck;
using Squer.Workshops.PropertyBasedTesting.Production;

namespace Squer.Workshops.PropertyBasedTesting.Tests.Generators;

public class ControlGenerator
{
    private static readonly DateTimeOffset MinDate = DateTimeOffset.UtcNow;
    private static readonly DateTimeOffset MaxDate = MinDate.AddHours(12);
    private static readonly int MinDateUnixTimeSeconds = (int)MinDate.ToUnixTimeSeconds();
    private static readonly int MaxDateUnixTimeSeconds = (int)MaxDate.ToUnixTimeSeconds();
    private static readonly int MaxDurationInSeconds = 60 * 60;

    private static Gen<DateTime> GenerateBeginTime() =>
        Gen.Choose(MinDateUnixTimeSeconds, MaxDateUnixTimeSeconds)
            .Select(unixTimeSeconds => DateTimeOffset.FromUnixTimeSeconds(unixTimeSeconds).LocalDateTime);

    private static Gen<PositiveTimeSpan> GenerateDuration() =>
        Arb.Default.NonNegativeInt().Generator
            .Where(nni => nni.Item <= MaxDurationInSeconds)
            .Select(nni => PositiveTimeSpan.FromSeconds((ulong)nni.Item));

    private static Gen<Control> GenerateControl() =>
        from begin in GenerateBeginTime()
        from duration in GenerateDuration()
        select new Control(begin, duration);

    public static Arbitrary<Control> ControlArbitrary => GenerateControl().ToArbitrary();
}