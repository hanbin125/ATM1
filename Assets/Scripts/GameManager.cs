using System.IO;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UserData userData;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI cashValueText;
    [SerializeField] private TextMeshProUGUI balanceValueText;

    private string saveFilePath;

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

        saveFilePath = Application.persistentDataPath + $"/{userData.ID}.json";

        LoadUserData();
        UpdateUI();
    }

    private void Update()
    {
        SaveUserData();
    }

    public void AddDeposit(int amount)
    {
        if (userData.cashValue < amount)
        {
            Debug.Log("잔액이 부족합니다");
            return;
        }
        userData.cashValue -= amount;
        userData.balanceValue += amount;
        UpdateUI();
    }
    public void AddWithdraw(int amount)
    {
        if (userData.balanceValue < amount)
        {
            Debug.Log("잔액이 부족합니다");
            return;
        }
        userData.cashValue += amount;
        userData.balanceValue -= amount;
        UpdateUI();
    }

    public void UpdateUI()
    {
        nameText.text = userData.name;
        cashValueText.text = userData.cashValue.ToString("N0");
        balanceValueText.text = "Balance " + userData.balanceValue.ToString("N0");
    }

    void SaveUserData()
    {
        string json = JsonUtility.ToJson(userData);
        File.WriteAllText(saveFilePath, json);
    }

    void LoadUserData()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            userData = JsonUtility.FromJson<UserData>(json);
        }
    }
}
