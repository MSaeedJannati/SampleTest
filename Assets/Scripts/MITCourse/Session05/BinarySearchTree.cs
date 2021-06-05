using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinarySearchTree
{
    #region variables
    public BstNode firstNode;
    #endregion
    #region Constructors
    public BinarySearchTree(int FirstValue)
    {
        firstNode = new BstNode(FirstValue);
    }
    #endregion
    #region Properties

    #endregion
    #region Functions
    public void AddToTree(int Value)
    {
        BstNode node = new BstNode(Value);
        Insert(ref node);
    }
    public void Insert(ref BstNode node)
    {
        if (firstNode == null)
        {
            firstNode = node;
            return;
        }
        else
        {
            bool addToLeft;
            BstNode targetNode = findInsertionPoint(node.mValue, out addToLeft);
            node.parentNode = targetNode;
            if (addToLeft)
            {
                targetNode.leftNode = node;
            }
            else
            {
                targetNode.rightNode = node;
            }
        }
    }
    public BstNode findInsertionPoint(int Amount, out bool addToLeft)
    {
        bool found = false;
        addToLeft = false;
        BstNode node = firstNode;
        while (!found)
        {
            if (Amount > node.mValue)
            {
                if (node.rightNode == null)
                {
                    found = true;
                    addToLeft = false;
                    continue;
                }
                else
                {
                    node = node.rightNode;
                }
            }
            else
            {
                if (node.leftNode == null)
                {
                    found = true;
                    addToLeft = true;
                    continue;
                }
                else
                {
                    node = node.leftNode;
                }
            }
        }
        return node;
    }

    #endregion
}
