namespace Squer.Workshops.PropertyBasedTesting.Production;

public static class Operations
{
    public static int Add(int a, int b)
    {
        if (b == 0) return a;
        if (a == 0) return b;
        return 0;
    }
}