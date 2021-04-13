using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BstNode
{
    #region Variables
    BstNode leftNode = null;
    BstNode parentNode = null;
    BstNode rightNode = null;
    int mValue;
    int nodesCount;
    #endregion
    #region Constructors
    public BstNode(int Value)
    {
        mValue = Value;
        nodesCount = 1;
    }
    public BstNode(BstNode parent, int Value)
    {
        mValue = Value;
        nodesCount = 1;
        parentNode = parent;
    }
    #endregion
    #region properties
    public BstNode RightNode
    {
        get
        {
            return rightNode;
        }
        set
        {
            rightNode = value;
        }
    }
    public BstNode LeftNode
    {
        get
        {
            return leftNode;
        }
        set
        {
            leftNode = value;
        }
    }
    public BstNode ParentNode
    {
        get
        {
            return parentNode;
        }
        set
        {
            ParentNode = value;
        }
    }
    public int Value
    {
        get
        {
            return mValue;
        }
        set
        {
            mValue = value;
        }
    }
    public int NodesCount
    {
        get
        {
            return nodesCount;
        }
        set
        {
            nodesCount = value;
        }
    }
    #endregion
}
