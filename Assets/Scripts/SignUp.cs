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

    public void SignUpBtn()
    {
        if(string.IsNullOrEmpty(IDText.text)|| string.IsNullOrEmpty(nameText.text)|| string.IsNullOrEmpty(PSText.text)|| string.IsNullOrEmpty(PSCFText.text))
        {
            Debug.Log("������ �Է����ּ���~");
            return;
        }

        if (PSText.text == PSCFText.text)
        {
            UserData userData = new UserData(IDText.text, nameText.text, PSText.text, 50000,100000);
            GameManager.instance.userData = userData;
            signUp.SetActive(false);
            login.SetActive(true);
        }
        else
        {
            Debug.Log("��й�ȣ�� ��ġ���� �ʽ��ϴ�.");
        }
    }

    public void LoginBtn()
    {
        if (string.IsNullOrEmpty(IDText.text) || string.IsNullOrEmpty(PSText.text))
        {
            Debug.Log("������ �Է����ּ���~");
            return;
        }
        if (GameManager.instance.userData.ID == IDText.text && GameManager.instance.userData.PS == PSText.text)
        {
            popupBank.SetActive(true);
            login.SetActive(false);
        }
        else
        {
            Debug.Log("���̵� �Ǵ� ��й�ȣ�� Ʋ�Ƚ��ϴ�.");
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
