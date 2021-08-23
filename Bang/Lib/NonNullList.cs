using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Bang.Lib;
public class NonNullList<T> : IList<T> where T : notnull
{
    [NotNull]
    public static NonNullList<T> Empty
    {
        get;
    } = new();

    public NonNullList()
    {
        TrueList = new();
    }

    private NonNullList(int length)
    {
        TrueList = new(length);
    }

    private NonNullList(List<T> other)
    {
        TrueList = other;
    }

    public NonNullList(NonNullList<T> other)
    {
        var otherTrueList = new T[other.Count];
        other.TrueList.CopyTo(otherTrueList, 0);
        TrueList = new(otherTrueList);
    }

    private readonly T? _filler;

    public NonNullList([NotNull] T filler, int length)
    {
        if (filler is null)
        {
            throw new ArgumentNullException(nameof(filler));
        }
        _filler = filler;
        TrueList = new(length);
        for (int i = 0; i < length; i++)
        {
            TrueList.Add(filler);
        }
    }

    [NotNull]
    private List<T> TrueList;

    [NotNull]
    public T this[int index]
    {
        get => TrueList[index];
        set => TrueList[index] = value;
    }

    public bool IsEmpty => TrueList.Count == 0;

    public int Count => TrueList.Count;

    public int LastIndex => IsEmpty ? 0 : Count - 1;

    public bool IsReadOnly => false;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public virtual void Add([NotNull] T item)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        TrueList.Add(item);
    }

    public void Clear()
    {
        if (_filler is null)
        {
            TrueList.Clear();
        }
        else
        {
            for (int i = 0; i < Count; i++)
            {
                this[i] = _filler;
            }
        }
    }

    public bool Contains(T item)
    {
        return item is not null && TrueList.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        TrueList.CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (T item in TrueList)
        {
            yield return item;
        }
    }

    public int IndexOf(T item)
    {
        return TrueList.IndexOf(item);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <param name="item"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public virtual void Insert(int index, [NotNull] T item)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        TrueList.Insert(index, item);
    }

    public virtual void Insert(int index, [NotNull] NonNullList<T> other)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        if (other is null)
        {
            throw new ArgumentNullException(nameof(other));
        }
        var insertedCount = other.Count;
        var totalLength = Count + insertedCount;
        var res = new T[totalLength];
        other.CopyTo(res, index);
        for (int i = 0; i < index; i++)
        {
            res[i] = this[i];
        }
        for (int i = index; i < Count; i++)
        {
            res[i + insertedCount] = this[i];
        }
        TrueList = new(res);
    }
    public virtual void InsertLast([NotNull] T item)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        TrueList.Insert(LastIndex, item);
    }

    public bool Remove(T item)
    {
        return TrueList.Remove(item);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void RemoveAt(int index)
    {
        TrueList.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Gets the sub list whose range is [start,end).<br/>
    /// If parameter end is more than this list's count, it'll be truncated.
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns>the sub list</returns>
    public virtual NonNullList<T> GetSubList(int start, int end)
    {
        if (start < 0 || start > Count - 1)
        {
            throw new ArgumentOutOfRangeException(nameof(start));
        }
        end = Math.Min(Count, end);
        var res = new NonNullList<T>();
        for (int i = start; i < end; i++)
        {
            res.Add(this[i]);
        }
        return res;
    }

    /// <summary>
    /// Gets the sub list whose range is [0,end).<br/>
    /// If parameter end is more than this list's count, it'll be truncated.
    /// </summary>
    /// <param name="end"></param>
    /// <returns>the sub list</returns>
    public virtual NonNullList<T> GetSubList(int end)
    {
        end = Math.Min(Count, end);
        var res = new NonNullList<T>();
        for (int i = 0; i < end; i++)
        {
            res.Add(this[i]);
        }
        return res;
    }

    public void Shuffle([NotNull] Random random)
    {
        TrueList = TrueList.OrderBy(x => random.Next()).ToList();
    }

    public void Shuffle()
    {
        Shuffle(new Random());
    }
}

internal class EmptyNonNullList<T> : NonNullList<T> where T : notnull
{
    public override void Add([NotNull] T item)
    {
    }
    public override void Insert(int index, [NotNull] T item)
    {
    }
    public override NonNullList<T> GetSubList(int end)
    {
        return Empty;
    }
    public override NonNullList<T> GetSubList(int start, int end)
    {
        return Empty;
    }
}
