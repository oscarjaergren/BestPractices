using System.Runtime.InteropServices;

namespace PlayGround.Iterations;

public class Iterations
{
    private static readonly Random Random = new(90000);

    private readonly List<int> _items;

    public Iterations()
    {
        _items = Enumerable.Range(1, 100).Select(x => Random.Next()).ToList();
    }

    public void ForEach_Span()
    {
        foreach (int item in CollectionsMarshal.AsSpan(_items))
        {
        }
    }
}