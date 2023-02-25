namespace PersonService.BLL.Contract;

public interface IDateTimeProvider
{
    DateTime UtcNow();
}