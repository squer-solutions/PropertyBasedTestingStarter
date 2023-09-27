using FluentAssertions;
using FsCheck;
using FsCheck.Xunit;
using Squer.Workshops.PropertyBasedTesting.Production;
using Squer.Workshops.PropertyBasedTesting.Production.Model;
using Squer.Workshops.PropertyBasedTesting.Tests.Generators;
using static Squer.Workshops.PropertyBasedTesting.Production.ControlMerger;

namespace Squer.Workshops.PropertyBasedTesting.Tests;

public class ControlMergeTests
{
    [Property(Arbitrary = new[] { typeof(ControlGenerator) })]
    public Property TwoTimesTheSameControl_ResultsInThatControl_BOOL_BASED(Control control)
    {
        var controls = ControlMerger.Merge(control, control);
        return (
            controls.Length == 1 && controls[0] == control
        ).ToProperty();
    }

    [Property(Arbitrary = new[] { typeof(ControlGenerator) })]
    public Property TwoTimesTheSameControl_ResultsInThatControl_ASSERTION_BASED(Control control) =>
        new Action(() =>
        {
            Merge(control, control)
                .Should().BeEquivalentTo(new[]
                {
                    control
                });
        }).ToProperty();


    [Property]
    public Property TwoTimesTheSameControl_ResultsInThatControl_EXPLICIT() =>
        Prop.ForAll(
            ControlGenerator.ControlArbitrary,
            CheckMerge
        );

    private static void CheckMerge(Control control)
    {
        var mergedControls = Merge(control, control);

        mergedControls
            .Should().BeEquivalentTo(
                new[] { control }
            );
    }

    [Property(Arbitrary = new[] { typeof(ControlGenerator) })]
    public Property TestControl(Control control) =>
        (
            control.Start.Day == 27
        )
        .And(
            control.Duration.Value.TotalSeconds >= 0
        );
}