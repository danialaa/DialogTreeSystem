using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[Serializable]
public class DialogTree
{
    [SerializeField]
    List<DialogTreeNode> nodes = new List<DialogTreeNode>();

    public void addNode(DialogTreeNode node)
    {
        nodes.Add(node);
    }

    public DialogTreeNode getNode(int id)
    {
        DialogTreeNode nodeWithID = null;

        nodeWithID = nodes.FirstOrDefault(node => node.id == id);

        return nodeWithID;
    }

    public void addToExits(List<DialogOption> options)
    {
        List<DialogTreeNode> nodesList = nodes.Where(node => node.isExit).ToList();
        
        foreach(DialogTreeNode node in nodesList)
        {
            node.options = options;
        }
    }

    public DialogTreeNode getNodeByPosition(int pos)
    {
        return nodes[pos];
    }

    public bool isLoopable()
    {
        foreach(DialogTreeNode node in nodes)
        {
            if (!node.options.Any(node => nodes[node.id].isExit))
            {
                return true;
            }
        }

        return false;
    }
}
