using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiEvents : MonoBehaviour
{
    #region Delegates
    public  delegate void myVoidDelegate();

    #endregion
    #region events
    public static myVoidDelegate onJump;
    public static myVoidDelegate onShoot;
    #endregion
    #region Functions
    public void Shoot()
    {
        onShoot?.Invoke();
    }
    public void Jump()
    {
        onJump?.Invoke();
    }
    #endregion
}
