using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownFieldFeeder : MonoBehaviour
{
    [Header("Add options to Dropdown")]
    public TMP_Dropdown dropDown;
    public Dropdown dropDownUI;

    private void Start()
    {
        Feed();
    }

    [ContextMenu("FeedMobileCode")]
    public void Feed()
    {
        if (dropDown != null)
        {
            dropDown.ClearOptions();

            string path = Application.streamingAssetsPath + "/PhoneNumberExtension.txt";

            string[] texts = System.IO.File.ReadAllLines(path);

            List<string> options = new List<string>();

            foreach (string line in texts)
            {
                options.Add(line);
            }

            dropDown.AddOptions(options);
        }

        if(dropDownUI != null)
        {
            dropDownUI.ClearOptions();

            string path = Application.streamingAssetsPath + "/PhoneNumberExtension.txt";

            string[] texts = System.IO.File.ReadAllLines(path);

            List<string> options = new List<string>();

            foreach (string line in texts)
            {
                options.Add(line);
            }

            dropDownUI.AddOptions(options);
        }
    }

}
