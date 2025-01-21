namespace _exercicePile.Classes;

public class Pile<T>
{
    private T?[] _elements = Array.Empty<T>();
    public T Add(T? item)
    {
        Array.Resize(ref _elements, _elements.Length + 1);
        _elements[^1] = item;
        return item;
    }

    public T? Remove()
    {
        if (_elements.Length > 0)
        {
            T result = _elements[^1];
            _elements = _elements[..^1];
            return result;
        }
        else
        {
            throw new IndexOutOfRangeException("No element found");
        }
    }

    public string ShowTableau()
    {
        if (_elements.Length > 0)
        {
            string result = "";

            foreach (T? element in _elements)
            {
                result += $"Element : {element}\n";
            }

            return result;
        }
        else
        {
           return "No element found";
        }
    }


    public T? GetIndex(int index)
    {
      if (index < 0 || index > _elements.Length)
        {
           throw new IndexOutOfRangeException("No element at this index");
        }

        if (_elements.Length > 0)
        {
            T result = _elements[^index];
            _elements = _elements[..^index];
            return result;
        }
        else
        {
           throw new IndexOutOfRangeException("No element found");
        }
    }


}