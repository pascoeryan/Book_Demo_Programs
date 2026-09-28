using BookUsingIterator;

public class Tester
{
    static void Main(string[] args)
    {
        DemoStack<Book> pile = new DemoStack<Book>(10);

        // 3 books in the stack, top-down means The Hobbit sits top of the pile.
        pile.Push(new Book("Dune"));
        pile.Push(new Book("1984"));
        pile.Push(new Book("The Hobbit"));

        Console.WriteLine("Walking the pile top-down:\n");

        foreach (Book b in pile)
        {
            Console.WriteLine(b);
        }

        Console.WriteLine("\nLooking for 1984:\n");

        bool found = false;

        foreach (Book b in pile) // Will communicate with the iterator to walk the pile searching for '1984'
        {
            if (b.Title == "1984")
            {
                Console.WriteLine("Found: " + b);
                found = true;
                break; // stops once 1984 is found
            }
        }

        if (!found)
        {
            Console.WriteLine("1984 is not in the pile.");
        }
    }
}
