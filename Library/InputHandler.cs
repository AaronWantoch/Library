using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class InputHandler
    {
        //Handles input from user and creates Book based on it
        public static Book LoadBook()
        {
            //TODO idiotodporność
            Category category = LoadCategory();
            Console.Write("Please write the day, month, year of the borrow: ");
            DateTime borrowDate = LoadDate();
            Console.Write("Please write the day, month, year of the return: ");
            DateTime returnDate = LoadDate();

            return new Book(category, borrowDate, returnDate);
        }

        private static DateTime LoadDate()
        {
            int day = Console.Read();
            int month = Console.Read();
            int year = Console.Read();
            return new DateTime(year, month, day);
        }

        private static Category LoadCategory()
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
            return (Category)Console.Read();
        }
    }
}
