using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UserData
{
    public string name;
    public int cashValue;
    public int balanceValue;

    public UserData(string name, int cash, int balance)
    {
        this.name = name;
        cashValue = cash;
        balanceValue = balance;
    }
}
