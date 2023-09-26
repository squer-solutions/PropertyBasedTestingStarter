using FluentAssertions;
using static Squer.Workshops.PropertyBasedTesting.Production.Operations;

namespace Tests;

public class AddTests
{
    [Fact]
    public void ZeroPlusZeroIsZero()
    {
        Add(0, 0).Should().Be(0);
    }
    
    
}