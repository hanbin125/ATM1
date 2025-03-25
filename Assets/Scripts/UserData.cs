using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UserData
{
    public string ID;
    public string PS;
    public string name;
    public int cashValue;
    public int balanceValue;

    public UserData(string id, string name, string ps,int cash,int balance)
    {
        this.ID = id;
        this.name = name;
        this.PS = ps;
        this.cashValue = cash;
        this.balanceValue = balance;
    }
}
