using FluentAssertions;
using FsCheck;
using FsCheck.Xunit;
using Xunit.Abstractions;
using static Squer.Workshops.PropertyBasedTesting.Production.Operations;

namespace Tests;

public class AddTests

{
    private readonly ITestOutputHelper _testOutputHelper;

    public AddTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

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
        _testOutputHelper.WriteLine($"{x},{y},{z}");
        return (Add(x, Add(y, z)) == Add(Add(x, y), z))
            .ToProperty();
    }

    [Property]
    public Property AddingOppositeNumbersIsZero(int x)
    {
        _testOutputHelper.WriteLine($"{x}");
        return (Add(x, -x) == 0)
            .ToProperty();
    }

    [Property]
    public Property SumOfOppositeNumbers(int x, int y)
    {
        _testOutputHelper.WriteLine($"{x},{y}");
        return (-Add(x, y) == Add(-x, -y))
            .ToProperty();
    }
}