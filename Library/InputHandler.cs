
namespace Library
{
    internal class InputHandler
    {
        //Handles input from user and creates Book based on it
        public static Book LoadBook()
        {
            DisplayCategories();
            Category category = LoadCategory();
            Console.Write("Please write the day, month, year of the borrow: ");
            DateTime borrowDate = LoadDate();
            Console.Write("Please write the day, month, year of the return: ");
            DateTime returnDate = LoadDate();

            return new Book(category, borrowDate, returnDate);
        }

        private static void DisplayCategories()
        {
            IEnumerable<Category> values = Enum.GetValues(typeof(Category)).Cast<Category>();
            Console.Write("Please pick a book category: ");
            foreach (Category c in values)
            {

                Console.Write("[{0}] {1}", (int)c, Enum.GetName(typeof(Category), c));
                if (c == values.Last())
                    Console.WriteLine();
                else
                    Console.Write(", ");

            }
        }

        private static Category LoadCategory()
        {
            Category category;
            while (true)
            {
                if(int.TryParse(Console.ReadLine(), out int number) && Enum.IsDefined(typeof(Category), number)) //Check if exists
                {
                    category = (Category) number;
                    break;
                }
                Console.WriteLine("Number that you typed doesn't match any category, please choose again");
            }
            return category;
        }

        private static DateTime LoadDate()
        {
            DateTime date;
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out date))
                    break;  
                Console.WriteLine("Can't find such date please type again");
            }
            return date;
        }

    }
}
