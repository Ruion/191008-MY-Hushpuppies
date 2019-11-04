using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class RegistrationController : MonoBehaviour
{
    public Button submitbtn;
    public InputField NameInput;
    public InputField PhoneInput;
    public InputField EmailInput;

    string MailPattern = @"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$";
    bool emailCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        emailCheck = Regex.IsMatch(EmailInput.text, MailPattern);
        if (NameInput.text != "" && PhoneInput.text != "" && EmailInput.text != "" && emailCheck)
        {
            submitbtn.interactable = true;
        }
    }

    public void GoToInstruction()
    {
        PlayerPrefs.SetString("RegistrationName", NameInput.text);
        PlayerPrefs.SetString("RegistrationPhone", PhoneInput.text);
        PlayerPrefs.SetString("RegistrationEmail", EmailInput.text);
        SceneManager.LoadScene("Instruction");
    }
}
