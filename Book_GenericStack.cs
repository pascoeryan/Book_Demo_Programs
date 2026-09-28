using System;

namespace BookUsingGenerics
{
    public class Book
    {
        public string Title { get; }

        public Book(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            return Title;
        }
    }

    public class DemoStack<T> // <T> is a generic type
    {
        private T[] array;
        private int count;

        public DemoStack(int capacity)
        {
            array = new T[capacity];
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public void Push(T item)
        {
            if (count >= array.Length)
                throw new InvalidOperationException("Stack is full.");

            array[count] = item;
            count++;
        }

        public T Pop()
        {
            if (count == 0)
                throw new InvalidOperationException("Stack is empty.");

            count--;
            T item = array[count];
            array[count] = default(T);
            return item;
        }

        public T Peek() // Looks at top of stack
        {
            if (count == 0)
                throw new InvalidOperationException("Stack is empty.");

            return array[count - 1];
        }
    }
}
