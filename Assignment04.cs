using System;
using System.Collections.Generic;

namespace Assignment04
{
    // ==========================================
    // Test your Knowledge
    // ==========================================
    /*
    1. Describe the problem generics address.
       Generics address type safety, code reuse, and performance issues (by avoiding boxing and unboxing of value types). They allow you to define classes and methods with placeholders for the types they store and manipulate.

    2. How would you create a list of strings, using the generic List class?
       List<string> myStrings = new List<string>();

    3. How many generic type parameters does the Dictionary class have?
       Two: TKey and TValue (Dictionary<TKey, TValue>).

    4. True/False. When a generic class has multiple type parameters, they must all match.
       False. (e.g., Dictionary<int, string> is perfectly valid).

    5. What method is used to add items to a List object?
       The Add() method.

    6. Name two methods that cause items to be removed from a List.
       Remove() and RemoveAt(). (Also Clear() removes all items).

    7. How do you indicate that a class has a generic type parameter?
       By adding angle brackets with a type parameter name after the class name, e.g., class MyClass<T> { ... }

    8. True/False. Generic classes can only have one generic type parameter.
       False. They can have multiple, separated by commas (e.g., Tuple<T1, T2>).

    9. True/False. Generic type constraints limit what can be used for the generic type.
       True.

    10. True/False. Constraints let you use the methods of the thing you are constraining to.
        True. If you constrain T to IMyInterface, you can call IMyInterface methods on objects of type T.
    */

    // ==========================================
    // Practice working with Generics
    // ==========================================

    // 1. Create a custom Stack class MyStack<T>
    public class MyStack<T>
    {
        private List<T> _items = new List<T>();

        public int Count()
        {
            return _items.Count;
        }

        public T Pop()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("Stack is empty.");

            int topIndex = _items.Count - 1;
            T item = _items[topIndex];
            _items.RemoveAt(topIndex);
            return item;
        }

        public void Push(T item)
        {
            _items.Add(item);
        }
    }

    // 2. Create a Generic List data structure MyList<T>
    public class MyList<T>
    {
        private List<T> _items = new List<T>();

        public void Add(T element)
        {
            _items.Add(element);
        }

        public T Remove(int index)
        {
            if (index < 0 || index >= _items.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            T removedItem = _items[index];
            _items.RemoveAt(index);
            return removedItem;
        }

        public bool Contains(T element)
        {
            return _items.Contains(element);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public void InsertAt(T element, int index)
        {
            _items.Insert(index, element);
        }

        public void DeleteAt(int index)
        {
            if (index < 0 || index >= _items.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            _items.RemoveAt(index);
        }

        public T Find(int index)
        {
            if (index < 0 || index >= _items.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            return _items[index];
        }
    }

    // 3. Implement a GenericRepository<T> class
    // Type constraint: reference type (class) and Entity type with Id property
    public class Entity
    {
        public int Id { get; set; }
    }

    public interface IRepository<T> where T : Entity
    {
        void Add(T item);
        void Remove(T item);
        void Save();
        IEnumerable<T> GetAll();
        T GetById(int id);
    }

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private List<T> _data = new List<T>();

        public void Add(T item)
        {
            if (item != null)
                _data.Add(item);
        }

        public void Remove(T item)
        {
            if (item != null)
                _data.Remove(item);
        }

        public void Save()
        {
            // Simulate saving to a data source
            Console.WriteLine("Data saved successfully.");
        }

        public IEnumerable<T> GetAll()
        {
            return _data;
        }

        public T GetById(int id)
        {
            // Since T is required to be an Entity through the class implementation constraint:
            foreach (var item in _data)
            {
                if ((item as Entity)?.Id == id)
                    return item;
            }
            return null; 
        }
    }

    // Re-applying the Entity constraint properly on the GenericRepository
    public class GenericEntityRepository<T> : IRepository<T> where T : Entity
    {
        private List<T> _data = new List<T>();

        public void Add(T item)
        {
            if (item != null)
                _data.Add(item);
        }

        public void Remove(T item)
        {
            if (item != null)
                _data.Remove(item);
        }

        public void Save()
        {
            Console.WriteLine("Data saved successfully.");
        }

        public IEnumerable<T> GetAll()
        {
            return _data;
        }

        public T GetById(int id)
        {
            foreach (var item in _data)
            {
                if (item.Id == id)
                    return item;
            }
            return null; 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assignment 04 completed.");
            
            // Brief demo
            var repo = new GenericEntityRepository<Entity>();
            repo.Add(new Entity { Id = 1 });
            repo.Add(new Entity { Id = 2 });
            repo.Save();
            
            int count = 0;
            foreach (var e in repo.GetAll()) count++;
            Console.WriteLine($"Repository has {count} entities.");
        }
    }
}
