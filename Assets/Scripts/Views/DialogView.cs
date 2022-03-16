using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogView : MonoBehaviour
{
    [SerializeField]
    TMP_Text name;
    [SerializeField]
    TMP_Text text;
    [SerializeField]
    Button option1;
    [SerializeField]
    Button option2;
    [SerializeField]
    Button option3;

    public void initializeDialog(string name, string text, string option1Text, string option2Text, string option3Text, DialogController.goNextInvoker optionEvent,
                                 int option1ID, int option2ID, int option3ID)
    {
        this.name.text = name;
        this.text.text = text;

        initializeOptionButton(option1, option1Text, optionEvent, option1ID);
        initializeOptionButton(option2, option2Text, optionEvent, option2ID);
        initializeOptionButton(option3, option3Text, optionEvent, option3ID);
    }

    void initializeOptionButton(Button optionButton, string optionText, DialogController.goNextInvoker optionEvent, int id)
    {
        optionButton.onClick.RemoveAllListeners();
        optionButton.gameObject.transform.Find("OptionText").GetComponent<TMP_Text>().text = "";
        optionButton.enabled = false;

        if (!string.IsNullOrEmpty(optionText))
        {
            optionButton.enabled = true;
            optionButton.gameObject.transform.Find("OptionText").GetComponent<TMP_Text>().text = optionText;
            optionButton.onClick.AddListener(delegate { optionEvent.Invoke(id); });
        }
    }
}
