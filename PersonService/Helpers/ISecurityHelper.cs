namespace PersonService.Helpers
{
    public interface ISecurityHelper
    {
        string GetJwtToken(string userName);
        string GetUserName(string token);
    }
}