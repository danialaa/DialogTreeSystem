using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneController : MonoBehaviour
{
    public DialogOpener dialogOpener;
    public TMP_Text hintText;

    bool dialogStarted = false;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (dialogOpener != null && !dialogStarted)
            {
                dialogOpener.startDialog();
                dialogStarted = true;
                hintText.gameObject.SetActive(false);
            }
        }
    }
}
