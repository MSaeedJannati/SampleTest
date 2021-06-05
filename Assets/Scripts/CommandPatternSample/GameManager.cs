using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager instance;
    [SerializeField] List<PieceHandler> pieces;
    GridManager gridManager;
    [SerializeField] List<Command> commandsHistory;
    [SerializeField] int curCommandIndx;
    public static event System.Action<int, int, GridManager.movePieceDelegate> onMove;
    bool pressed;
    Vector2Int deltaPos;
    #endregion
    #region monobehaviour callbacks
    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(this);

            }
            return;
        }
        initialize();
    }
    private void Start()
    {
        gridManager?.createPlayer();
    }
    private void Update()
    {
        pressed = false;
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            pressed = true;
            deltaPos.x = 0;
            deltaPos.y = 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            pressed = true;
            deltaPos.x = 0;
            deltaPos.y = -1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            pressed = true;
            deltaPos.x = 1;
            deltaPos.y = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            pressed = true;
            deltaPos.x = -1;
            deltaPos.y = 0;
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Z))
        {
            print("Here");
            OnUndo();
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Y))
        {
            OnRedo();
        }
        if (pressed)
        {
            directionInput(deltaPos.x, deltaPos.y);
        }
    }
    #endregion
    #region Functions
    void initialize()
    {
        pieces = new List<PieceHandler>();
        TryGetComponent(out gridManager);
        commandsHistory = new List<Command>();
    }
    public void addPiece(PieceHandler piece)
    {
        int index = checkForRedundancies();
        if (index != -1)
        {
            pieces[index] = piece;
        }
        else
        {
            pieces.Add(piece);
        }
    }
    public int checkForRedundancies()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            if (pieces[i] == null)
                return i;

        }
        return -1;
    }
    public void addCommand(Command command)
    {
        if (commandsHistory.Count > 0)
        {
            if (curCommandIndx != commandsHistory.Count - 1)
            {
                commandsHistory.RemoveRange(curCommandIndx + 1, commandsHistory.Count - 1);
            }
        }
        commandsHistory.Add(command);
        curCommandIndx= commandsHistory.Count - 1;
    }
    public void OnUndo()
    {
        if (curCommandIndx > 0)
        {
            commandsHistory[curCommandIndx].undo();
            curCommandIndx--;
        }
    }
    public void OnRedo()
    {
        if (curCommandIndx < commandsHistory.Count - 1)
        {
            commandsHistory[curCommandIndx].redo();
            curCommandIndx++;
        }
    }
    public void Move(int x, int y, GridManager.movePieceDelegate callBack)
    {
        onMove?.Invoke(x, y, callBack);
    }
    public void directionInput(int deltaX,int deltaY)
    {
        MoveCommand command = new MoveCommand(pieces[0].X, pieces[0].Y);
        command.execute(deltaX, deltaY, pieces[0].gameObject);
        addCommand(command);
    }
    #endregion
}
