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
        string path = Application.streamingAssetsPath + "/PhoneNumberExtension.txt";
        string[] texts;
        List<string> options = new List<string>();

        if (Application.platform == RuntimePlatform.Android)
        {
            BetterStreamingAssets.Initialize();

            //  path = "jar:file://" + Application.dataPath + "!/assets/" + fileName + ".setting";
            path = "PhoneNumberExtension.txt";

            if (!BetterStreamingAssets.FileExists(path))
            {
                Debug.LogErrorFormat("Streaming asset not found: {0}", path);
                return;
            }

            texts = BetterStreamingAssets.ReadAllLines(path);
        }
        else
        {
            texts = System.IO.File.ReadAllLines(path);
        }

        if (dropDown != null)
        {
            dropDown.ClearOptions();

            options = new List<string>();

            foreach (string line in texts)
            {
                options.Add(line);
            }

            dropDown.AddOptions(options);
        }

        if (dropDownUI != null)
        {
            dropDownUI.ClearOptions();

            path = Application.streamingAssetsPath + "/PhoneNumberExtension.txt";

            texts = System.IO.File.ReadAllLines(path);

            options = new List<string>();

            foreach (string line in texts)
            {
                options.Add(line);
            }

            dropDownUI.AddOptions(options);
        }
     }
 }

