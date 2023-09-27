using FluentAssertions;
using FsCheck;
using FsCheck.Xunit;
using static Squer.Workshops.PropertyBasedTesting.Production.Operations;

namespace Squer.Workshops.PropertyBasedTesting.Tests;

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

    [Property]
    public Property ZeroIsIdentity(int x)
    {
        return (Add(x, 0) == x)
            .ToProperty();
    }

    [Property]
    public Property AddSupportsAssociation(int x, int y, int z)
    {
        return (Add(x, Add(y, z)) == Add(Add(x, y), z))
            .Collect($"({x}, {y}, {z})");
    }

    [Property]
    public Property AddingOppositeNumbersIsZero(int x)
    {
        return (Add(x, -x) == 0)
            .Collect($"{x}");
    }

    [Property]
    public Property SumOfOppositeNumbers(int x, int y)
    {
        return (-Add(x, y) == Add(-x, -y))
            .Collect($"({x}, {y})");
    }
}