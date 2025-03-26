using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupBank : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] GameObject deposit;
    [SerializeField] GameObject withdraw;
    [SerializeField] GameObject remit;
    [SerializeField] Button depositBtn10000;
    [SerializeField] Button depositBtn30000;
    [SerializeField] Button depositBtn50000;
    [SerializeField] TMP_InputField InputField;
    [SerializeField] TMP_InputField InputField2;
    [SerializeField] TMP_InputField InputField3;
    [SerializeField] TMP_InputField RemitID;
    [SerializeField] Button cancelBtn;
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
        main.SetActive(false);
        deposit.SetActive(true);
    }
    public void Openwithdraw()
    {
        main.SetActive(false);
        withdraw.SetActive(true);
    }
    public void Openremit()
    {
        main.SetActive(false);
        remit.SetActive(true);
    }
    public void CancelBtn()
    {
        deposit.SetActive(false);
        withdraw.SetActive(false);
        remit.SetActive(false);
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

    //public void AddRemit(int amount)
    //{
    //    GameManager.instance.AddRemit(amount,);
    //}


    public void AddCustomDeposit()
    {
        string a = InputField.text.ToString();
        isamount = int.TryParse(a, out int amount);

        if (isamount)
        {
            AddDeposit(amount);
        }
        else
        {
            Debug.Log("���ڸ� �Է����ּ���");
        }
        InputField.text = "";
    }

    public void AddCustomWithdraw()
    {
        string a = InputField2.text.ToString();
        isamount = int.TryParse(a, out int amount);
        if (isamount)
        {
            AddWithdraw(amount);
        }
        else
        {
            Debug.Log("���ڸ� �Է����ּ���");
        }
        InputField2.text = "";
    }

    
    public void AddCustomRemit()
    {
        if (string.IsNullOrEmpty((RemitID.text)))
        {
            Debug.Log("���̵� �Է����ּ���");
            return;
        }

        if(GameManager.instance.userData.ID == RemitID.text)
        {
            Debug.Log("�ڽſ��� �۱��� �� �����ϴ�.");
            return;
        }

        UserData remitUser = GameManager.instance.LoadUserData(RemitID.text);
        
        if (remitUser!=null)
        {
            string a = InputField3.text.ToString();
            isamount = int.TryParse(a, out int amount);
            if (isamount)
            {
                GameManager.instance.AddRemit(amount, remitUser);
            }
            else
            {
                Debug.Log("���ڸ� �Է����ּ���");
            }
            InputField3.text = "";
        }

        else
        {
            Debug.Log("�������� �ʴ� ���̵��Դϴ�.");
        }
    }
}
