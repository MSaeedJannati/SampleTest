using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    PieceHandler piece;
    public MoveCommand(int x, int y): base (x,y)
    {

    }
    public override void execute(int deltaX,int deltaY, GameObject receiver)
    {
        if (receiver.TryGetComponent(out piece))
        {
            piece.onMoveInput(deltaX, deltaY);
            formerX = curX;
            formerY = curY;
            curX += deltaX;
            curY += deltaY;
        }
    }
    public override void undo()
    {
        piece?.onMoveInput(formerX-curX,formerY-curY);
    }
    public override void redo()
    {
        piece?.onMoveInput(curX-formerX  , curY-formerY);
    }
}

