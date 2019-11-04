using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPageController : MonoBehaviour
{
    public GameObject Over500Page;
    public GameObject Below500Page;
    public GameObject LosePage;


    int score;
    string name;
    string phone;
    string email;

    // Start is called before the first frame update
    void Start()
    {
        name = PlayerPrefs.GetString("RegistrationName", "0");
        phone = PlayerPrefs.GetString("RegistrationPhone", "0");
        email = PlayerPrefs.GetString("RegistrationEmail", "0");
        score = PlayerPrefs.GetInt("Score", 0);

        if(score <= 100)
        {
            LosePage.SetActive(true);
        }
        else if(score > 100 && score <= 500)
        {
            Below500Page.SetActive(true);
        }
        else if(score > 500)
        {
            Over500Page.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToHome()
    {
        SceneManager.LoadScene("Home");
    }
}
