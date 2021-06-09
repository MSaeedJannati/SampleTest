using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarPositionHandler : MonoBehaviour
{
    #region Variables
    [SerializeField] int carNumber;
    [SerializeField] Transform mTransform;
    [SerializeField] float angle;
    [SerializeField] float currentAngle;
    [SerializeField] float lastAngle;
    Vector3 relativePos;
    float rawAngle;
    [SerializeField] int lapCount;
    [SerializeField] Color colour;
    [SerializeField] TMP_Text carNumText;
    [SerializeField] SpriteRenderer mRenderer;
    #endregion
    #region Properties
    public float Angle => angle;
    public int Number { 
        get => carNumber; 
    }
    public Color Colour => colour;
    #endregion
    #region monobehaviour callBacks
    private void Start()
    {
        calcAngel();
        currentAngle = angle;
        lastAngle = angle;
        lapCount = 0;
        colour = mRenderer.color;
        RaceTrack.AddCar(this);
    }
    private void Update()
    {
        lastAngle = currentAngle;
        calcAngel();
        checkForLapCount();
        angle = lapCount * 360 + currentAngle;
    }

    
    #endregion
    #region Functions
    public void calcAngel()
    {
        relativePos = mTransform.position - RaceTrack.Center.position;
        rawAngle = Mathf.Atan(relativePos.y / relativePos.x)*180/Mathf.PI;
        if (relativePos.x <= 0 && relativePos.y <= 0)
        {
            rawAngle = rawAngle + 180;
        }
        else if (relativePos.x <= 0 && relativePos.y >= 0)
        {
            rawAngle = rawAngle + 180;
        }
        else if (relativePos.x >= 0 && relativePos.y <= 0)
        {
            rawAngle = rawAngle + 360;
        }
        currentAngle = rawAngle;
    }
    public void checkForLapIncrease()
    {
        if (lastAngle >= 270 && lastAngle < 360)
        {
            if (currentAngle >= 0 && currentAngle <= 90)
            {
                lapCount++;
            }
        }
    }
    public void checkForLapDecrease()
    {
        if (lastAngle >=0 && lastAngle <= 90)
        {
            if (currentAngle >= 270 && currentAngle <= 360)
            {
                lapCount--;
            }
        }
    }
    void checkForLapCount()
    {
        checkForLapIncrease();
        checkForLapDecrease();
    }
    public void setCarNumber(int Number)
    {
        carNumber = Number;
        carNumText.text = carNumber.ToString();
    }
    #endregion
}
