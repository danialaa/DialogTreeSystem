using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class DialogController : MonoBehaviour
{
    [SerializeField]
    DialogView view;

    string name;
    DialogTree tree = new DialogTree();
    UnityEngine.Events.UnityEvent exitEvent = new UnityEngine.Events.UnityEvent();

    DialogTreeNode currentNode = null;
    List<int> traversedPath = new List<int>();
    bool isReplaying = false;
    int posInPath = 0;

    goNextInvoker del;

    public void initializeDialog(DialogTree tree, string name, UnityEngine.Events.UnityAction exitAction)
    {
        this.tree = tree;
        this.name = name;

        exitEvent.AddListener(exitAction);

        del = new goNextInvoker(goNext);
        int firstID = tree.getNodeByPosition(0).id;

        setCurrentNode(firstID);
        traversedPath.Add(0);

        if (tree.isLoopable()) Debug.LogWarning("Be careful! Users can get stuck in your tree dialog");
    }

    void resetDialog()
    {
        currentNode = null;
        traversedPath.Clear();
        isReplaying = false;
        posInPath = 0;
    }

    public delegate void goNextInvoker(int optionID);

    void setCurrentNode(int id)
    {
        currentNode = tree.getNode(id);

        if(!isReplaying || currentNode.isExit)
        {
            view.initializeDialog(name, currentNode.text, currentNode.options.Count > 0 ? currentNode.options[0].optionText : "",
                                                              currentNode.options.Count > 1 ? currentNode.options[1].optionText : "",
                                                              currentNode.options.Count > 2 ? currentNode.options[2].optionText : "",
                                                         del, currentNode.options.Count > 0 ? currentNode.options[0].id : -1,
                                                              currentNode.options.Count > 1 ? currentNode.options[1].id : -1,
                                                              currentNode.options.Count > 2 ? currentNode.options[2].id : -1);
        }
        else
        {
            int idOfNext = currentNode.options[traversedPath[posInPath + 1]].id;
            string optionOfNext = currentNode.options[traversedPath[posInPath + 1]].optionText;

            view.initializeDialog(name, currentNode.text, optionOfNext, "", "", del, idOfNext, -1, -1);
        }
    }

    void goNext(int optionID)
    {
        if (!currentNode.isExit)
        {
            if (!isReplaying)
            {
                traversedPath.Add(currentNode.options.IndexOf(currentNode.options.FirstOrDefault(node => node.id == optionID)));
            }
            else
            {
                posInPath++;
            }

            setCurrentNode(optionID);
        }
        else
        {
            if (optionID == 0)
            {
                isReplaying = true;
                posInPath = 0;

                setCurrentNode(tree.getNodeByPosition(0).id);
            }
            else if (optionID == 1)
            {
                resetDialog();
                exitEvent.Invoke();
            }
        }
    }
}
