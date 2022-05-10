
namespace Library
{
    internal class Program
    {
       public static void Main()
       {
            Library library = new Library();

            while(true)
            {
                Book book = InputHandler.LoadBook();
                decimal penalty = library.CalculatePenalty(book);
                if (penalty != 0)
                    Console.WriteLine("borrower penalty fee is {0}", penalty);
                else
                    Console.WriteLine("borrower has no fee to pay");
                Console.WriteLine("Do you want to exit? [y/N]");
                if (Console.ReadLine().ToLower() == "y")
                    break;
            }

       }
    }
}
