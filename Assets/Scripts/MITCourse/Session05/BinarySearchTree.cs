using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinarySearchTree  
{
    #region variables
    BstNode firstNode;
    #endregion
    #region Constructors
    BinarySearchTree(int FirstValue)
    {
        firstNode=new BstNode(FirstValue);
    }
    #endregion
    #region Properties

    #endregion
    #region Functions
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
            BstNode targetNode = findInsertionPoint(node.Value, out addToLeft);
            node.ParentNode = targetNode;
            if (addToLeft)
            {
                targetNode.LeftNode = node;
            }
            else
            {
                targetNode.RightNode = node;
            }
        }
    }
    public BstNode findInsertionPoint(int Amount,out bool addToLeft)
    {
        bool found = false;
        addToLeft = false;
        BstNode node = firstNode;
        while (!found)
        {
            if (Amount > node.Value)
            {
                if (node.RightNode == null)
                {
                    found = true;
                    addToLeft = false;
                    continue;
                }
                else
                {
                    node = node.RightNode;
                }
            }
            else
            {
                if (node.LeftNode == null)
                {
                    found = true;
                    addToLeft = true;
                    continue;
                }
                else
                {
                    node = node.LeftNode;
                }
            }
        }
        return node;
    }
    
    #endregion
}
