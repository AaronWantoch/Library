using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Library
    {
        public Dictionary<Category, decimal> Penalties { get; }

        public Library()
        {
            Penalties = new Dictionary<Category, decimal>();
            SetPeanlties();
        }

        //returns false if no penalty, true if there is penalty and sets parameter penalty acordingly
        public bool CalculatePenalty(Book book, out decimal penalty)
        {
            int daysLate = Utils.GetDiferenceInDays(book.BorrowedDate, book.ReturnedDate);
            if(daysLate <= 1)
            {
                penalty = 0;
                return false;
            }
            penalty = daysLate * Penalties[book.Category];
            return true;
        }

        private void SetPeanlties()
        {
            Penalties[Category.IT] = 5;
            Penalties[Category.History] = 3;
            Penalties[Category.Classic] = 2;
            Penalties[Category.Law] = 2;
            Penalties[Category.Medical] = 2;
            Penalties[Category.Philosophy] = 2;
        }
    }
}
