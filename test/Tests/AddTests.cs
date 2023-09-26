using FluentAssertions;
using FsCheck;
using FsCheck.Xunit;
using static Squer.Workshops.PropertyBasedTesting.Production.Operations;

namespace Tests;

public class AddTests
{
    [Fact]
    public void ZeroPlusZeroIsZero()
    {
        Add(0, 0).Should().Be(0);
    }

    [Property]
    public Property AddIsCommutative(int x, int y)
    {
        return (Add(x, y) == Add(y, x))
            .ToProperty();
    }
}