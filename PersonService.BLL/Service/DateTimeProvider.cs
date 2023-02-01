using PersonService.BLL.Contract;

namespace PersonService.BLL.Service
{
    internal class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
