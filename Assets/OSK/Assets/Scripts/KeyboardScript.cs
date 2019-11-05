using UnityEngine;
using System;

public class KeyboardScript : MonoBehaviour
{

    public AudioSource clickSound;
    int selectionStartPost;
    int selectionEndPost;
    int selectionAmount;

    private void OnEnable()
    {
        if (Application.platform == RuntimePlatform.Android)
            gameObject.SetActive(false);
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
            gameObject.SetActive(false);
    }

    public TMPro.TMP_InputField inputFieldTMPro_
    {
        get { return inputFieldTMPro; }
        set
        {
            inputFieldTMPro = value;
        }
    }

    public TMPro.TMP_InputField inputFieldTMPro;
    public GameObject EngLayoutSml, EngLayoutBig, SymbLayout;

    public void alphabetFunction(string alphabet)
    {
        clickSound.Play();
        bool canType = true;

        if (inputFieldTMPro.contentType == TMPro.TMP_InputField.ContentType.IntegerNumber)
        {
            int out_;
            if (!int.TryParse(alphabet, out out_)) canType = false;
            // if(int.TryParse(alphabet, out out_)) inputFieldTMPro.text += alphabet;

        }

        
        if (canType)
        {
            inputFieldTMPro.text += alphabet; // SAFE
            /*
            if (!SelectionFocus())
            {
                inputFieldTMPro.stringPosition += alphabet.Length;
               inputFieldTMPro.text = inputFieldTMPro.text.Insert(inputFieldTMPro.stringPosition, alphabet);
                

            }
            else
            {
                RemoveSelectionTexts();
                inputFieldTMPro.stringPosition += alphabet.Length;
                inputFieldTMPro.text = inputFieldTMPro.text.Insert(inputFieldTMPro.stringPosition, alphabet);
                
            }
            */
        }
    }

    public void BackSpace()
    {
        if (inputFieldTMPro.text.Length < 0) return;

        clickSound.Play();

         if (inputFieldTMPro.text.Length>0) inputFieldTMPro.text= inputFieldTMPro.text.Remove(inputFieldTMPro.text.Length-1);

        

        /*
        int cutPos = inputFieldTMPro.stringPosition - 1;

        if (!SelectionFocus())
        {
            if (inputFieldTMPro.stringPosition - 1 < 0) return;
            string newText = inputFieldTMPro.text.Remove(cutPos, 1);
            inputFieldTMPro.text = newText;
            inputFieldTMPro.stringPosition = cutPos;
        }
        else
        {
            RemoveSelectionTexts();
        }
        */

       // inputFieldTMPro.Select();
        //  if (inputFieldTMPro.stringPosition <= 0) inputFieldTMPro.MoveTextEnd(false);

    }

    public void ShowSelectionDetails()
    {
        SelectionFocus();
        Debug.Log("selectionStartPost : " + selectionStartPost + " , " + "selectionEndPost : " + selectionEndPost + ", amount : " + selectionAmount);
    }

    private bool SelectionFocus()
    {
        if (inputFieldTMPro.selectionStringAnchorPosition < inputFieldTMPro.selectionStringFocusPosition)
        {
            selectionStartPost = inputFieldTMPro.selectionStringAnchorPosition;
            selectionEndPost = inputFieldTMPro.selectionStringFocusPosition;
        }
        else
        {
            selectionStartPost = inputFieldTMPro.selectionStringFocusPosition;
            selectionEndPost = inputFieldTMPro.selectionStringAnchorPosition;
        }

        selectionAmount = selectionEndPost - selectionStartPost;

        if ((selectionAmount) >= 1) return true;

        return false;
    }

    private void RemoveSelectionTexts()
    {
        inputFieldTMPro.text = inputFieldTMPro.text.Remove(selectionStartPost, selectionAmount);
        inputFieldTMPro.stringPosition = selectionStartPost;
    }

    public void CloseAllLayouts()
    {
        EngLayoutSml.SetActive(false);
        EngLayoutBig.SetActive(false);
        SymbLayout.SetActive(false);

    }

    public void ShowLayout(GameObject SetLayout)
    {
        clickSound.Play();
        CloseAllLayouts();
        SetLayout.SetActive(true);

    }

}
