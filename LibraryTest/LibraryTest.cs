using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
