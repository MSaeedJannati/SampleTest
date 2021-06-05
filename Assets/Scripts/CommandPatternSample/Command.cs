using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command 
{
    protected int curX;
    protected int curY;
    protected int formerX;
    protected int formerY;
    public Command(int x, int y)
    {
        curX = x;
        curY = y;
    }
    public virtual void execute(int deltaX,int deltaY,GameObject receiver) 
    { 

    }
    public virtual void undo() { }
    public virtual void redo() { }

}
