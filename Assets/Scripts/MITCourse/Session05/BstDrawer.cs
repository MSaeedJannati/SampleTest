using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BstDrawer : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject NodePrefab;
    [SerializeField] Transform NodeParentTransform;
    #endregion
    #region Functions
    public void drawBst(BinarySearchTree bst)
    {
        for (int i = 0; i < NodeParentTransform.childCount;i++)
        {
            Destroy(NodeParentTransform.GetChild(i).gameObject);
        }
        drawNode(bst.firstNode, NodeParentTransform);
    }
    public void drawNode(BstNode node,Transform targetTransform)
    {
        BstNodeUi nodeUi= ObjectPool.Instantiate(NodePrefab, targetTransform).GetComponent<BstNodeUi>();
        nodeUi.valueText.text = node.mValue.ToString();
        if (node.rightNode != null)
        {
            drawNode(node.rightNode, nodeUi.rightTransform);
        }
        if (node.leftNode != null)
        {
            drawNode(node.leftNode, nodeUi.leftTransform);
        }
    }
   
    #endregion


}
