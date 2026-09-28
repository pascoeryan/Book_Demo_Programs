using BookUsingGenerics;

public class Tester
{
    static void Main(string[] args)
    {
        DemoStack<Book> pile = new DemoStack<Book>(10);

        pile.Push(new Book("Dune"));
        pile.Push(new Book("1984"));
        pile.Push(new Book("The Hobbit"));

        Console.WriteLine("Book at top of the pile: " + pile.Peek());
        Console.WriteLine("Count (number of books): " + pile.Count);
        Console.WriteLine();

        // Demonstration of the pile being destroyed, using Pop() to find the book '1984'
        Console.WriteLine("Before search");
        Console.WriteLine("Count: " + pile.Count);
        Console.WriteLine("Top: " + pile.Peek());
        Console.WriteLine();

        Console.WriteLine("Searching for 1984 by popping...\n");

        bool found = false;

        while (pile.Count > 0)
        {
            Book b = pile.Pop(); // Pops books starting from the top of the pile
            Console.WriteLine("Popped: " + b);

            if (b.Title == "1984")
            {
                found = true;
                Console.WriteLine("Found it."); // Found it... but at what cost?
                break;
            }
        }

        Console.WriteLine();
        Console.WriteLine("After search");
        Console.WriteLine("Found: " + found);
        Console.WriteLine("Count: " + pile.Count);

        if (pile.Count > 0)
            Console.WriteLine("Top book now: " + pile.Peek());
        else
            Console.WriteLine("Pile is empty.");
    }
}
