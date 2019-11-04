using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections;
using TMPro;
using DataBank;

public class FormValidator : ServerModelMaster
{

    #region variables
    bool Text1OK = false;
    bool Text2OK = false;
    bool Text3OK = false;
    bool userIsUnique = true;

    public Button Submit;
    public Button virtualSubmit;


    public TMP_InputField NameText;
    public TMP_InputField PhoneText;
    public TMP_InputField EmailText;

    string MailPattern = @"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$";

    string PhonePattern = @"^6?01\d{7,9}$";

    public GameObject emailWarning;
    public GameObject phoneWarning;

    private List<string> emailList;
    private List<string> contactList;
    public UniversalUserDB udb;

    private int oskID;
    public float validateFrequency;
    #endregion

    private void Start()
    {
        udb.ConnectDbCustom();

        emailList = udb.GetDataByStringToList("email");
        contactList = udb.GetDataByStringToList("contact");

        udb.Close();
    }

    // Update is called once per frame
    void Update()
    {
        if (Text1OK && Text2OK && Text3OK && userIsUnique)
        {
            Submit.interactable = true;
            virtualSubmit.interactable = true;
        }
        else
        {
            Submit.interactable = false;
            virtualSubmit.interactable = false;
        }

    }

    public void StartValidateOnFrequency()
    {
        InvokeRepeating("Validate", 2f, validateFrequency);
    }

    public void StopValidateOnFrequency()
    {
        CancelInvoke("Validate");
    }

    private void Validate()
    {
        T1Change();
        T2Change();
        T3Change();
        CheckUserExists();
    }

    public void T1Change()
    {
        Text1OK = InputNotEmpty(NameText);
    }

    public void T2Change()
    {
        Text2OK = Regex.IsMatch(PhoneText.text, PhonePattern);
    }

    public void T3Change()
    {
        Text3OK = Regex.IsMatch(EmailText.text, MailPattern);
    }

    private bool InputNotEmpty(TMP_InputField text)
    {
        bool notEmpty = true;

        if (text.text == "" || text.text == null) notEmpty = false;

        return notEmpty;
    }

    public void CheckUserExists()
    {
        userIsUnique = ToggleWarnings();
     //  if(!userIsUnique) Debug.Log("user not unique");
    }

    private bool ToggleWarnings()
    {
        bool isUnique = true;

        bool emailIsUnique = ToggleEmailWarning();
        bool phoneIsUnique = TogglePhoneWarning();

        if (emailIsUnique || phoneIsUnique)
        {
            isUnique = false;
        }

        return isUnique;
    }

    private bool ToggleEmailWarning()
    {
        bool hasSame = false;

        if (ValidateDuplicate(emailList, EmailText))
        {
            emailWarning.SetActive(true);
            hasSame = true;
         //   Debug.Log("email not unique");
        }
        else
        {
            emailWarning.SetActive(false);
            hasSame = false;
            
        }

        return hasSame;
    }

    private bool TogglePhoneWarning()
    {
        bool hasSame = false;

        if (ValidateDuplicate(contactList, PhoneText))
        {
            phoneWarning.SetActive(true);
            hasSame = true;
          //  Debug.Log("phone not unique");
        }
        else
        {
            phoneWarning.SetActive(false);
            hasSame = false;
            
        }

        return hasSame;
    }

    private bool ValidateDuplicate(List<string> source, TMP_InputField text_)
    {
        bool hasSame = false;

        string same = source.FirstOrDefault(t => t == text_.text);
        if (same != null) hasSame = true;

        return hasSame;
    }

    public void DoCombineServerUsers()
    {
        StartCoroutine(CombineServerUsers());
    }

    private IEnumerator CombineServerUsers()
    {
        OnlineServerModel osm = FindObjectOfType<OnlineServerModel>();

        yield return StartCoroutine(osm.GetDataFromServer());

        for (int i = 0; i < osm.emailList.Count; i++)
        {
            AddUniqueUser(osm.emailList[i], emailList);
        }
    }
}
