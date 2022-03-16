using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[Serializable]
public class DialogTreeNode
{
    public string text = "";
    public int id = -1;
    public List<DialogOption> options = new List<DialogOption>();
    public bool isExit
    {
        get
        {
            return options.Count == 0 || options.Any(option => option.optionText == "Exit") ? true : false;
        }
    }
}
