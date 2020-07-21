using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumpadPuzzle : MonoBehaviour
{
    public string Input = "";
    public Text Text;
    public OpenNumPuzzle OpenNumPuzzle;

    private string WinVal_1 = "6020060150";
    private string WinVal_2 = "1506020060";
    //private char[] CharsToTrim = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '<', '>', '#', '*' };
   
    public void Button_1()
    {
        Input += '1';
        Text.text = Input;
    }
    public void Button_2()
    {
        Input += '2';
        Text.text = Input;
    }
    public void Button_3()
    {
        Input += '3';
        Text.text = Input;
    }
    public void Button_4()
    {
        Input += '4';
        Text.text = Input;
    }
    public void Button_5()
    {
        Input += '5';
        Text.text = Input;
    }
    public void Button_6()
    {
        Input += '6';
        Text.text = Input;
    }
    public void Button_7()
    {
        Input += '7';
        Text.text = Input;
    }
    public void Button_8()
    {
        Input += '8';
        Text.text = Input;
    }
    public void Button_9()
    {
        Input += '9';
        Text.text = Input;
    }
    public void Button_0()
    {
        Input += '0';
        Text.text = Input;
    }
    public void Button_Enter()
    {
        Win();
    }
    public void Button_Del()
    {
        int Length = Input.Length;
        Input = Input.Remove(Length - 1);
        Text.text = Input;
    }
    public void Button_Less()
    {
        Input += "<";
        Text.text = Input;
    }
    public void Button_Greater()
    {
        Input += ">";
        Text.text = Input;
    }
    public void Button_Hash()
    {
        Input += "#";
        Text.text = Input;
    }
    public void Button_Star()
    {
        Input += "*";
        Text.text = Input;
    }

    private void Win()
    {
        if (WinVal_1.Equals(Input) || WinVal_2.Equals(Input))
        {
            OpenNumPuzzle.Solved();
        }
    }
    //public void Exit()
    //{
    //    Input = "";
       
    //}
}