using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BstNode
{
    #region Variables
    public BstNode leftNode = null;
    public BstNode parentNode = null;
    public BstNode rightNode = null;
    public int mValue;
    public int nodesCount;
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
    //public BstNode RightNode
    //{
    //    get
    //    {
    //        return rightNode;
    //    }
    //    set
    //    {
    //        rightNode = value;
    //    }
    //}
    //public BstNode LeftNode
    //{
    //    get
    //    {
    //        return leftNode;
    //    }
    //    set
    //    {
    //        leftNode = value;
    //    }
    //}
    //public BstNode ParentNode
    //{
    //    get
    //    {
    //        return parentNode;
    //    }
    //    set
    //    {
    //        ParentNode = value;
    //    }
    //}
    //public int Value
    //{
    //    get
    //    {
    //        return mValue;
    //    }
    //    set
    //    {
    //        mValue = value;
    //    }
    //}
    //public int NodesCount
    //{
    //    get
    //    {
    //        return nodesCount;
    //    }
    //    set
    //    {
    //        nodesCount = value;
    //    }
    //}
    #endregion
}
