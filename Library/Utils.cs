
namespace Library
{
    public class Utils
    {
        public static int GetDiferenceInDays(DateTime date1, DateTime date2)
        {
            return Math.Abs((date1 - date2).Days);
        }
    }
}
