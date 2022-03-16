using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public DialogOpener dialogOpener;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (dialogOpener != null)
            {
                dialogOpener.startDialog();
            }
        }
    }
}
