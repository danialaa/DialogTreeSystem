using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogOption
{
    public int id = -1;
    public string optionText = "";

    public DialogOption(int id, string optionText)
    {
        this.id = id;
        this.optionText = optionText;
    }
}
