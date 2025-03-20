using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UserData userData;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI cashValueText;
    public TextMeshProUGUI balanceValueText;
    public Button depositBtn10000;
    public Button depositBtn30000;
    public Button depositBtn50000;
    public Button withdrawBtn10000;
    public Button withdrawBtn30000;
    public Button withdrawBtn50000;
    public Button cancelBtn;

    private List<int> moneyAmounts = new List<int> { 10000, 30000, 50000, 100000, 200000 };
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        nameText = GameObject.Find("Name").GetComponent<TextMeshProUGUI>();
        cashValueText = GameObject.Find("cashValue").GetComponent<TextMeshProUGUI>();
        balanceValueText = GameObject.Find("balanceValue").GetComponent<TextMeshProUGUI>();
        userData = new UserData("최한빈", 50000, 100000);
        UpdateUI();

        depositBtn10000.onClick.AddListener(Deposit);
    }

    public void UpdateUI()
    {
        nameText.text = userData.name;
        cashValueText.text = userData.cashValue.ToString("N0");
        balanceValueText.text = "Balance " + userData.balanceValue.ToString("N0");
    }

    public void Deposit()
    {
        userData.cashValue -= 10000;
        userData.balanceValue += 10000;
        UpdateUI();
    }

    public void Withdraw()
    {
        userData.cashValue += 10000;
        userData.balanceValue -= 10000;
        UpdateUI();
    }
}
