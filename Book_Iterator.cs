using System;
using System.Collections;
using System.Collections.Generic;

namespace BookUsingIterator
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

    public class DemoStack<T> : IEnumerable<T> // IEnumerable is an interface, which promises DemoStack that GetEnumerator() will be used
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

        public T Peek()
        {
            if (count == 0)
                throw new InvalidOperationException("Stack is empty.");

            return array[count - 1];
        }

        public IEnumerator<T> GetEnumerator() 
        {
            return new Iterator(array, count); // Takes the current DemoStack array and count
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); // Creates a small iterator object that stores a reference to the array (number and positions)
        }

        // Nested Iterator class... this is important as the nested private class can see the field values (ie, Dune, 1984, The Hobbit)
        private class Iterator : IEnumerator<T> 
        {
            private T[] array;
            private int count;
            private int position;

            public Iterator(T[] array, int count)
            {
                this.array = array;
                this.count = count;
                this.position = count; // One past the top
            }

            // MoveNext and Current read the iterator object and serve as the "loop" that walks the stack
            public bool MoveNext() 
            {
                position--; // Changes position, so from top of the stack to second top for example
                return position >= 0;
            }

            public T Current
            {
                get { return array[position]; } // Returns current position in array
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Reset()
            {
                position = count;
            }

            public void Dispose()
            {
            }
        }
    }
}
