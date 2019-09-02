using System;

public class ArrayList<T>
{
    public int Count { get; set; }
    public T[] items { get; set; }

    public ArrayList()
    {
        this.Count = 2;
        this.items = new T[this.Count];
    }

    public T this[int index]
    {
        get
        {
            if (index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
            return items[index];
        }

        set
        {
            if (index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
            items[index] = value;
        }
    }

    public void Add(T item)
    {
        for (int i = 0; i < this.items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
            }
        }
    }

    public T RemoveAt(int index)
    {
        T value = items[index];
        items.SetValue(null, index);
        return value;
    }

    private void Resize()
    {

    }
}
