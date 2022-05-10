using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book
    {
        public Category Category { get; private set; }
        public DateTime BorrowedDate { get; private set; }
        public DateTime ReturnedDate { get; private set; }

        public Book(Category category, DateTime borrowedDate, DateTime returnedDate)
        {
            Category = category;
            BorrowedDate = borrowedDate;
            ReturnedDate = returnedDate;
        }

    }
}
