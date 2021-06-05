using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceHandler : MonoBehaviour
{
    #region Variables
    [SerializeField] int x;
    [SerializeField] int y;
    Transform myTransform;
    #endregion
    #region Properties
    public int X => x;
    public int Y => y;
    #endregion
    #region monbehaviour callbacks
    public void setPosIndecies(int mX, int mY)
    {
        if (mX >= 0 && mX < GridManager.GridTileCount)
            x = mX;
        if (mY >= 0 && mY < GridManager.GridTileCount)
            y = mY;
    }
    private void OnEnable()
    {
        GameManager.instance.addPiece(this);
        TryGetComponent(out myTransform);
    }
    #endregion
    #region Functions
    public void onMoveInput(int deltaX, int deltaY)
    {
        x += deltaX;
        x = Mathf.Clamp(x, 0, GridManager.GridTileCount-1);
        y += deltaY;
        y= Mathf.Clamp(y, 0, GridManager.GridTileCount-1);
        GameManager.instance.Move(x, y, ChangePos);

    }

    public void ChangePos(Vector3 newPos)
    {
        myTransform.position = newPos;
    }
    #endregion
}
