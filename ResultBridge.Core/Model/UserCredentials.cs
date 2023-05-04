﻿namespace ResultBridge.Core.Model;

public class UserCredentials
{
    public UserCredentials(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public string UserName { get; }
    public string Password { get; }
}