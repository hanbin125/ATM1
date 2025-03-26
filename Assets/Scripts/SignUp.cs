using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SignUp : MonoBehaviour
{
    [SerializeField] GameObject login;
    [SerializeField] GameObject signUp;
    [SerializeField] GameObject popupBank;
    [SerializeField] private TMP_InputField IDText;
    [SerializeField] private TMP_InputField nameText;
    [SerializeField] private TMP_InputField PSText;
    [SerializeField] private TMP_InputField PSCFText;
    [SerializeField] private TMP_InputField LoginID;
    [SerializeField] private TMP_InputField LoginPS;
    public void SignUpBtn()
    {
        if(string.IsNullOrEmpty(IDText.text)|| string.IsNullOrEmpty(nameText.text)|| string.IsNullOrEmpty(PSText.text)|| string.IsNullOrEmpty(PSCFText.text))
        {
            Debug.Log("정보를 입력해주세요~");
            return;
        }

        if (PSText.text == PSCFText.text)
        {
            UserData newUser = new UserData(IDText.text, nameText.text, PSText.text, 50000,100000);
            GameManager.instance.InitializeUser(newUser);
            signUp.SetActive(false);
            login.SetActive(true);
        }
        else
        {
            Debug.Log("비밀번호가 일치하지 않습니다.");
        }
    }

    public void LoginBtn()
    {
        if (string.IsNullOrEmpty(LoginID.text) || string.IsNullOrEmpty(LoginPS.text))
        {
            Debug.Log("정보를 입력해주세요~");
            return;
        }

        GameManager.instance.userData = GameManager.instance.LoadUserData(LoginID.text);
        if (GameManager.instance.userData != null && GameManager.instance.userData.ID == LoginID.text && GameManager.instance.userData.PS == LoginPS.text)
        {
            popupBank.SetActive(true);
            login.SetActive(false);
            GameManager.instance.UpdateUI();
        }
        else
        {
            Debug.Log("아이디 또는 비밀번호가 틀렸습니다.");
        }
    }

    public void OpenSignUp()
    {
        login.SetActive(false);
        signUp.SetActive(true);
    }

    public void CloseSignUp()
    {
        signUp.SetActive(false);
        login.SetActive(true);
    }

}
