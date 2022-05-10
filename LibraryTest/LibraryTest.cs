using NUnit.Framework;
using Library;

namespace LibraryTest
{
    [TestFixture]
    public class LibraryTest
    {
        [Test]
        public void Penalties_AllCategoriesFilled_NoException()
        {
            Library.Library library = new Library.Library();
            IEnumerable<Category> values = Enum.GetValues(typeof(Category)).Cast<Category>();
            //Checking if all categories have penalty assigned
            foreach (Category c in values)
            {
                var _ = library.Penalties[c];
            }
        }

        [Test]
        public void DateDifference_OneDayDiffrence()
        {
            DateTime date1 = new DateTime(2022, 5, 8);
            DateTime date2 = new DateTime(2022, 5, 7);
            Assert.AreEqual(Utils.GetDiferenceInDays(date1, date2), 1);
        }

        [Test]
        public void DateDifference_Order()
        {
            DateTime date1 = new DateTime(2022, 5, 8);
            DateTime date2 = new DateTime(2022, 5, 7);
            Assert.AreEqual(Utils.GetDiferenceInDays(date2, date1), 1);
        }

        [Test]
        public void DateDifference_0Days()
        {
            DateTime date1 = new DateTime(2022, 5, 8);
            DateTime date2 = new DateTime(2022, 5, 8);
            Assert.AreEqual(Utils.GetDiferenceInDays(date2, date1), 0);
        }

        [Test]
        public void DateDifference_Month()
        {
            DateTime date1 = new DateTime(2022, 5, 8);
            DateTime date2 = new DateTime(2022, 6, 8);
            Assert.AreEqual(Utils.GetDiferenceInDays(date2, date1), 31);
        }

        [Test]
        public void DateDifference_LargeDifference()
        {
            DateTime date1 = new DateTime(2022, 5, 8);
            DateTime date2 = new DateTime(2021, 3, 17);
            Assert.AreEqual(Utils.GetDiferenceInDays(date2, date1), 417);
        }

        [Test]
        public void Penalty_0DaysLateLaw()
        {
            Library.Library library = new Library.Library();
            DateTime borrowDate = new DateTime(2022, 1, 1);
            DateTime returnDate = new DateTime(2022, 1, 1);
            Category category = Category.Law;
            Book book = new Book(category, borrowDate, returnDate);

            Assert.AreEqual(library.CalculatePenalty(book), 0);
        }

        [Test]
        public void Penalty_1DayLateMedical()
        {
            Library.Library library = new Library.Library();
            DateTime borrowDate = new DateTime(2022, 1, 1);
            DateTime returnDate = new DateTime(2022, 1, 2);
            Category category = Category.Medical;
            Book book = new Book(category, borrowDate, returnDate);

            Assert.AreEqual(library.CalculatePenalty(book), 0);
        }

        //Example from task description
        [Test]
        public void Penalty_2DaysLateIT() 
        {
            Library.Library library = new Library.Library();
            DateTime borrowDate = new DateTime(2022, 1, 1);
            DateTime returnDate = new DateTime(2022, 1, 3);
            Category category = Category.IT;
            Book book = new Book(category, borrowDate, returnDate);

            Assert.AreEqual(library.CalculatePenalty(book), 10);
        }

        [Test]
        public void Penalty_5DaysLateHistory()
        {
            Library.Library library = new Library.Library();
            DateTime borrowDate = new DateTime(2022, 1, 1);
            DateTime returnDate = new DateTime(2022, 1, 6);
            Category category = Category.History;
            Book book = new Book(category, borrowDate, returnDate);

            Assert.AreEqual(library.CalculatePenalty(book), 15);
        }
    }
}
