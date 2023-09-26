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
}