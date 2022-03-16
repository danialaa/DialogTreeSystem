using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOpener : MonoBehaviour
{
    [SerializeField]
    GameObject dialogPrefab;
    [SerializeField]
    string dialogJSONName;
    [SerializeField]
    string name = "";

    private void Start()
    {
        var dialogInJSON = Resources.Load<TextAsset>(dialogJSONName);
        
        if (string.IsNullOrEmpty(dialogInJSON.text))
        {
            Debug.LogError("Please attach JSON file to dialog opener");
            return;
        }

        DialogTree tree = null;

        try
        {
            tree = JsonUtility.FromJson<DialogTree>("{\"nodes\":" + dialogInJSON.text + "}");
        }
        catch
        {
            Debug.LogError("Could not deserialize JSON");
            return;
        }

        List<DialogOption> exitOptions = new List<DialogOption>();
        exitOptions.Add(new DialogOption(0, "Replay"));
        exitOptions.Add(new DialogOption(1, "Exit"));

        tree.addToExits(exitOptions);

        if (dialogPrefab == null)
        {
            Debug.LogError("Please attach dialog prefab to dialog opener");
        }
        else
        {
            dialogPrefab = Instantiate(dialogPrefab, dialogPrefab.transform.position, Quaternion.identity);
            dialogPrefab.SetActive(false);
            dialogPrefab.transform.Find("Controller").GetComponent<DialogController>().initializeDialog(tree, name, exitDialog);
        }
    }

    public void startDialog()
    {
        dialogPrefab.SetActive(true);
    }

    void exitDialog()
    {
        dialogPrefab.SetActive(false);
    }
}
