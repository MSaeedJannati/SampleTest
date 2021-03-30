using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Variables
    [SerializeField] Transform TargetTransform;
    [SerializeField] Transform mTransform;
    float lerpFactor;
    float distance;
    float threshhold = .1f;
    Vector3 speed = Vector3.one * .3f;
    float stationaryFieldOfView = 60.0f;
    float movingFieldOfView = 65.0f;
    [SerializeField] Camera myCamera;
    #endregion
    #region Monobehaviour callBacks
    private void LateUpdate()
    {
        mTransform.position = Vector3.SmoothDamp(mTransform.position, TargetTransform.position,ref speed,.5f);
        mTransform.rotation = Quaternion.Slerp(mTransform.rotation, TargetTransform.rotation, 2f * Time.deltaTime);
        if ((mTransform.position - TargetTransform.position).sqrMagnitude > threshhold)
        {
            myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, movingFieldOfView, 2f * Time.deltaTime);
        }
        else
        {
            myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, stationaryFieldOfView, 2f * Time.deltaTime);
        }
    }
    #endregion
}
