using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BstUsing : MonoBehaviour
{
    #region Variables
    [SerializeField]BstDrawer drawerReference;
    #endregion
    #region Functions
    [ContextMenu("Draw tree")]
    public void ShowBinaryTree()
    {
        BinarySearchTree bst = new BinarySearchTree(12);
        bst.AddToTree(15);
        bst.AddToTree(1);

        bst.AddToTree(18);
        bst.AddToTree(16);
        bst.AddToTree(24);
        drawerReference.drawBst(bst);
    }
    #endregion
}
