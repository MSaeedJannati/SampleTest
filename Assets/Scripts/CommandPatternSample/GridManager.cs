using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    #region Variables
    [SerializeField] int tileCount;
    [SerializeField] float boardSize;
    [SerializeField] Material myMaterial;
    [SerializeField] Transform myTransform;
    List<Vector3> gridPoses;
    [SerializeField] GameObject piecePrefab;
    public delegate void movePieceDelegate(Vector3 pos);

    public static int GridTileCount;
    #endregion
    #region properties
    List<Vector3> GridPoses => gridPoses;
    #endregion
    #region Monobehaviour callbacks
    private void OnEnable()
    {
        initializeBoard();
        GameManager.onMove += movePiece;
        GridTileCount = tileCount;
    }
    private void OnDestroy()
    {
        GameManager.onMove -= movePiece;
    }
    #endregion
    #region Functions
    void setMaterialTileSize()
    {
        myMaterial.SetVector("_Tiling", new Vector4((float)tileCount / 2, (float)tileCount / 2, 0, 0));
    }
    void setBoardSize()
    {
        myTransform.localScale = Vector3.one * boardSize;
    }
    void setBoardPos()
    {
        Vector3 pos = Camera.main.transform.position;
        pos.z = 0;
        myTransform.position = pos;
    }
    void initializeBoard()
    {

        setMaterialTileSize();
        setBoardSize();
        setBoardPos();
        calculateCellsPos();
    }
    void calculateCellsPos()
    {
        float boardLength = 0;
        if (TryGetComponent<SpriteRenderer>(out var renderer))
        {
            boardLength = renderer.bounds.size.x;
        }
        gridPoses = new List<Vector3>(tileCount * tileCount);
        float cellLength = boardLength / tileCount;
        Vector3 boardDownLeft = myTransform.position - boardLength / 2 * Vector3.one;
        boardDownLeft.z = 0;

        for (int i = 0; i < tileCount; i++)
        {
            for (int j = 0; j < tileCount; j++)
            {
                gridPoses.Add(boardDownLeft + new Vector3((j + .5f), (i + .5f), 0) * cellLength);
            }
        }
    }
    public void createPlayer()
    {
        int pos = getRandomPos();
        if (ObjectPool.Instantiate(piecePrefab, gridPoses[pos], Quaternion.identity).TryGetComponent(out PieceHandler piece))
        {
            piece.setPosIndecies(pos% tileCount, pos/ tileCount);
        }

    }
    int getRandomPos()
    {
        return Random.Range(0, gridPoses.Count);
    }
    public void movePiece(int newX, int newY, movePieceDelegate callBack)
    {
        if (newX < 0)
            newX = 0;
        if (newX > tileCount - 1)
            newX = tileCount - 1;
        if (newY < 0)
            newY = 0;
        if (newY > tileCount - 1)
            newY = tileCount - 1;
        int index = newY * tileCount + newX;
        
        callBack?.Invoke(gridPoses[index]);
    }
    #endregion
}
