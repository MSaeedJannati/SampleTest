using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    #region variables
    [SerializeField] float speed;
    [SerializeField] float angularSpeed;
    [SerializeField] Transform mTransform;
    [SerializeField] float moveTreshhold;
    Vector3 movement = new Vector3();

    [SerializeField] Dpad moveDpad;
    [SerializeField] Dpad rotateDpad;
    [SerializeField] Vector3 rotation;



    float vDeltaRotation = 0.0f;
    float hDeltaRotation = 0.0f;
    float EulerX = 0.0f;
    float EulerY = 0.0f;

    Quaternion DestRot;
    Quaternion Yrot;

    public delegate void myVoidDelegate();
    public static event myVoidDelegate onShoot;
    #endregion
    #region monobehaviour callbacks
    private void Start()
    {
        Vector3 eulerAngles = mTransform.rotation.eulerAngles;
        EulerX = eulerAngles.x;
        EulerY = eulerAngles.y;
    }
    private void Update()
    {
        Move(moveDpad.Direction);
        Rotate(rotateDpad.Direction);
        if (Input.GetMouseButtonDown(0))
        {
            onShoot?.Invoke();
        }
    }
    #endregion
    #region Functions
    //    public void Rotate(Vector3 direction)
    //    {
    //        if (Mathf.Abs(direction.x) < moveTreshhold)
    //        {
    //            direction.x = 0;
    //        }
    //        if (Mathf.Abs(direction.y) < moveTreshhold)
    //        {
    //            direction.y = 0;
    //        }
    ///*        Vector3*/ rotation = angularSpeed * direction * Time.deltaTime;
    //        Quaternion currenRot = mTransform.rotation;
    //        currenRot *= Quaternion.Euler(0,rotation.x,0);
    //        currenRot*= Quaternion.Euler( -rotation.y, 0,0);
    //        rotation = currenRot.eulerAngles;
    //        rotation.x = Mathf.Clamp(rotation.y, -60.0f, 60.0f);
    //        currenRot = Quaternion.Euler(rotation);
    //        mTransform.rotation = currenRot;
    //    }
    public void Move(Vector3 direction)
    {
        //if (Vector3.Dot( direction,  direction) < moveTreshhold * moveTreshhold)
        //    return;
        if (Mathf.Abs(direction.x) < moveTreshhold)
        {
            direction.x = 0;
        }
        if (Mathf.Abs(direction.y) < moveTreshhold)
        {
            direction.y = 0;
        }

        movement = speed * direction * Time.deltaTime;
        mTransform.position += mTransform.forward * movement.y + mTransform.right * movement.x;
    }

    public void Rotate(Vector3 direction)
    {

        vDeltaRotation = direction.y;
        hDeltaRotation = direction.x;

        DestRot = Quaternion.identity;
        vDeltaRotation = vDeltaRotation * angularSpeed * Time.deltaTime;
        hDeltaRotation = hDeltaRotation * angularSpeed * Time.deltaTime;
        EulerX -= vDeltaRotation;
        EulerY += hDeltaRotation;
        Yrot = Quaternion.Euler(0f, EulerY, 0f);

        EulerX = Mathf.Clamp(EulerX, -20f, 20f);
        DestRot = Yrot * Quaternion.Euler(EulerX, 0f, 0f);
        mTransform.rotation = DestRot;
    }
    #endregion
}
