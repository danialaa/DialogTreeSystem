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

    void initializeDialog(string name, string text, string option1Text, string option2Text, string option3Text,
        UnityEngine.Events.UnityAction option1Event, UnityEngine.Events.UnityAction option2Event, UnityEngine.Events.UnityAction option3Event)
    {
        this.name.text = name;
        this.text.text = text;

        initializeOptionButton(option1, option1Text, option1Event);
        initializeOptionButton(option2, option2Text, option2Event);
        initializeOptionButton(option3, option3Text, option3Event);
    }

    void initializeOptionButton(Button optionButton, string optionText, UnityEngine.Events.UnityAction optionEvent)
    {
        if (!string.IsNullOrEmpty(optionText))
        {
            optionButton.gameObject.transform.Find("OptionText").GetComponent<TMP_Text>().text = optionText;
            optionButton.onClick.AddListener(optionEvent);
        }
        else
        {
            optionButton.enabled = false;
        }
    }
}
