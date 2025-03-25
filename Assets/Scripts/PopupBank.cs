using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupBank : MonoBehaviour
{
    public GameObject deposit;
    public GameObject withdraw;
    public GameObject main;
    [SerializeField] private Button depositBtn10000;
    [SerializeField] private Button depositBtn30000;
    [SerializeField] private Button depositBtn50000;
    public TMP_InputField depositInputField;
    [SerializeField] private Button cancelBtn;
    bool isamount;
    
    private void Awake()
    {
        List<int> moneyAmounts = new List<int> { 10000, 30000, 50000 };

        depositBtn10000.onClick.AddListener(() => AddDeposit(moneyAmounts[0]));
        depositBtn30000.onClick.AddListener(() => AddDeposit(moneyAmounts[1]));
        depositBtn50000.onClick.AddListener(() => AddDeposit(moneyAmounts[2]));
        //customMoney.onClick.AddListener(() => AddCustomDeposit(int.Parse(depositInputField.text)));
    }
    public void Opendeposit()
    {
        deposit.SetActive(true);
        main.SetActive(false);
    }
    public void Openwithdraw()
    {
        main.SetActive(false);
        withdraw.SetActive(true);
    }
    public void CancelBtn()
    {
        deposit.SetActive(false);
        withdraw.SetActive(false);
        main.SetActive(true);
    }
    private void Start()
    {
        //gameManager = GameManager.instance;
    }
    public void AddDeposit(int amount)
    {
        GameManager.instance.AddDeposit(amount);
    }

    public void AddWithdraw(int amount)
    {
        GameManager.instance.AddWithdraw(amount);
    }

    public void AddCustomDeposit()
    {
        string a = depositInputField.text.ToString();
        isamount = int.TryParse(a, out int amount);

        if (isamount)
        {
            AddDeposit(amount);
        }
        else
        {
            Debug.Log("숫자만 입력해주세요");
        }
    }
}
