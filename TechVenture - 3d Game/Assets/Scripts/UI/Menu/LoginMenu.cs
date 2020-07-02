using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginMenu : MonoBehaviour
{
    public GameObject Username;
    public GameObject Password;
    public GameObject MenuHeader;
    public GameObject WarningTxt;

    private bool SignUp = false;
    private string UsernameVal;
    private string PasswordVal;
    private PlayerData PlayerData;
    private string WrongInputMsg;
    private string WrongPassLenMsg;
    private string NoInputMsg;
    private void Awake()
    {
        // PlayerData = new PlayerData();
        if (SaveLoad.SaveExists("playerData"))
        {
            MenuHeader.GetComponent<TextMeshProUGUI>().text = "Login";
            PlayerData = SaveLoad.Load<PlayerData>("playerData");
        }
        else
        {
            SignUp = true;
            MenuHeader.GetComponent<TextMeshProUGUI>().text = "SignUp";
        }
        WrongInputMsg = "Wrong username or password !";
        WrongPassLenMsg = "Make Sure to use more than 4 Characters for password";
        NoInputMsg = "Please enter Both Username and Password";
        Debug.Log(Application.persistentDataPath);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (SignUp)
                SigningUp();
            else
                LogIn();
        }
    }


    public void Submit()
    {
        if (SignUp)
        {
            SigningUp();
        }
        else
        {
            LogIn();
        }
    }
    void LogIn()
    {
        UsernameVal = Username.GetComponent<TextMeshProUGUI>().text;
        PasswordVal = Password.GetComponent<InputField>().text;
        if (UsernameVal != null && PasswordVal != null)
        {
            if (UsernameVal.Equals(PlayerData.Username) && PasswordVal.Equals(PlayerData.Password))
                Debug.Log("LoggedIn");
            else
            {
                WarningTxt.GetComponent<TextMeshProUGUI>().text = WrongInputMsg;
            }
        }
        else
        {
            WarningTxt.GetComponent<TextMeshProUGUI>().text = NoInputMsg;
        }
       
    }
    void SigningUp()
    {
        UsernameVal = Username.GetComponent<TextMeshProUGUI>().text;
        PasswordVal = Password.GetComponent<InputField>().text;
        if (UsernameVal != null && PasswordVal != null)
        {
            if (PasswordVal.Length >= 4)
            {
                PlayerData = new PlayerData(UsernameVal, PasswordVal);
                SaveLoad.Save<PlayerData>(PlayerData, "playerData");
            }
            else
            {
                WarningTxt.GetComponent<TextMeshProUGUI>().text = WrongPassLenMsg;
            }
        }
        else
        {
            WarningTxt.GetComponent<TextMeshProUGUI>().text = NoInputMsg;
        }
    }
}
