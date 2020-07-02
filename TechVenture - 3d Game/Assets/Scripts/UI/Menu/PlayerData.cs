using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string Username;
    public string Password;

    public PlayerData(string username, string password)
    {
        Username = username;
        Password = password;
    }
}
