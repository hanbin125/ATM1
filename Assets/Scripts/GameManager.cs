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
    }

    public void InitializeUser(UserData newUser)
    {
        userData = newUser;
        saveFilePath = Application.persistentDataPath + $"/{userData.ID}.json";
        SaveUserData(userData);
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
        SaveUserData(userData);
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
        SaveUserData(userData);
    }
    public void AddRemit(int amount, UserData targetData)
    {
        if (userData.balanceValue < amount)
        {
            Debug.Log("잔액이 부족합니다");
            return;
        }

        targetData.balanceValue += amount;
        userData.balanceValue -= amount;
        UpdateUI();
        SaveUserData(userData);
        SaveUserData(targetData);
    }
    public void UpdateUI()
    {
        nameText.text = userData.name;
        cashValueText.text = userData.cashValue.ToString("N0");
        balanceValueText.text = "Balance " + userData.balanceValue.ToString("N0");
    }

    private string GeneratePath(string id)
    {
        return Application.persistentDataPath + $"/{id}.json";
    }

    public void SaveUserData(UserData targetData)
    {
        string json = JsonUtility.ToJson(targetData);
        File.WriteAllText(GeneratePath(targetData.ID), json);
    }

    public UserData LoadUserData(string userId)
    {
        string saveFilePath = GeneratePath(userId);
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            return JsonUtility.FromJson<UserData>(json);
        }
        else
        {
            Debug.Log("저장된 데이터가 없습니다.");
            return null;
        }
    }
}