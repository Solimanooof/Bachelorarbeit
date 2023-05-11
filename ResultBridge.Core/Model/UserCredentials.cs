namespace ResultBridge.Core.Model;

public interface IUserCredentials
{
    public string UserName { get; set; }
    public string Password { get; set; }

}
public class UserCredentials : IUserCredentials
{
    public UserCredentials(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public string UserName { get; set; }
    public string Password { get; set; }
}