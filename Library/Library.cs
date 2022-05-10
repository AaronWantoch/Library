
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

        public decimal CalculatePenalty(Book book)
        {
            int daysLate = Utils.GetDiferenceInDays(book.BorrowedDate, book.ReturnedDate);
            if(daysLate <= 1)
                return 0;
            return daysLate * Penalties[book.Category];
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
