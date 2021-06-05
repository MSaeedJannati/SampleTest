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

    [SerializeField] Transform muzzleTransform;
    [SerializeField] CharacterController mController;

    float JumpCoolDown = 1.0f;
    float lastJumpTime = -2.0f;
    #endregion
    #region monobehaviour callbacks
    private void OnEnable()
    {
        UiEvents.onJump += Jump;
    }
    private void Start()
    {
        //Vector3 eulerAngles = mTransform.rotation.eulerAngles;
        //EulerX = eulerAngles.x;
        //EulerY = eulerAngles.y;
        //Vector3 eulerAngles = mTransform.rotation.eulerAngles;
        //EulerX = muzzleTransform.rotation.eulerAngles.x;
        //EulerY = mTransform.rotation.eulerAngles.y;
    }
    private void Update()
    {
        Move(moveDpad.Direction);
        Rotate(rotateDpad.Direction);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    onShoot?.Invoke();
        //}
    }
    private void OnDisable()
    {
        UiEvents.onJump -= Jump;
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
    public void Jump()
    {
        //mController.Move(new Vector3(0,1.0f,0));
        //if (mController.isGrounded)
        StartCoroutine(jumpCoroutine());
    }
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

        movement = speed * direction /** Time.deltaTime*/;
        //mTransform.position += mTransform.forward * movement.y + mTransform.right * movement.x;
        mController.SimpleMove(mTransform.forward * movement.y + mTransform.right * movement.x);
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
        DestRot = Yrot  /* * Quaternion.Euler(EulerX, 0f, 0f)*/;
        muzzleTransform.localRotation = Quaternion.Euler(EulerX, 0f, 0f);
        mTransform.rotation = DestRot;
    }


    #endregion
    #region Coroutines
    public IEnumerator jumpCoroutine()
    {
        if (Time.time < lastJumpTime + JumpCoolDown)
            yield break;
        lastJumpTime = Time.time;
        float period = .2f;
        float t = 0.0f;
        float JumpHeight = 1.0f;


        //while (t < period)
        //{
        //    mController.Move(new Vector3(0, 1.0f, 0) * JumpHeight / period * Time.deltaTime);
        //    t += Time.deltaTime;
        //    yield return null;
        //}
        float jumpInitSpeed = 8.0f;
        float acceleration = -9.8f;
        bool firstMoment = true;
        Vector3 deltaPos = new Vector3(0, 1.0f, 0);
        t = 0.0f;
        while (!mController.isGrounded || firstMoment)
        {
            firstMoment = false;
            deltaPos.y = (jumpInitSpeed + acceleration * t) * Time.deltaTime;
            mController.Move(deltaPos);
            t += Time.deltaTime;
            yield return null;
        }
    }
    #endregion
}
