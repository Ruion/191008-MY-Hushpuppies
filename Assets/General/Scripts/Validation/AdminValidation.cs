﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AdminValidation : MonoBehaviour
{
    public string password = "hondaBoss";
    public TMPro.TMP_InputField passwordInput;

    public UnityEvent OnPasswordCorrect;


    public virtual void Validate()
    {
        if(passwordInput.text == password)
        {
            OnPasswordCorrect.Invoke();
            passwordInput.text = "";
           
        }
    }
}
