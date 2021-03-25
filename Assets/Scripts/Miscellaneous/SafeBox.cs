using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class SafeBox : MonoBehaviour
{
    #region Variables
    [SerializeField] string passWord;
    [SerializeField] string gearsData;
    int[] gearsInt;
    #endregion
    #region NaughtyAttriubutes
    [NaughtyAttributes.Button]
    public void Test()
    {
        parseData();
        findMoveCount();
    }

    #endregion
    #region Functions
    public void parseData()
    {
        string[] gears = gearsData.Split(' ');
        gearsInt = new int[gears.Length];
        for (int i = 0; i < gears.Length; i++)
        {
            gearsInt[i] = int.Parse(gears[i]);
            //print(gears[i]);
        }
    }
    public void findMoveCount()
    {
        int pass = int.Parse(passWord);
        int lastPass = pass;
        int pasDigit = 0;
        int gearDigit = 0;
        int lastGear = 0;
        int gear = 0;

        int moveCount = 0;
        bool matchFound = false;

        int counter = 0;

        int index = 0;
        int gearCount = gearsInt.Length;
        int firstDigit = 0;
        while (pass > 0)
        {
            index++;
            pasDigit = pass - (pass / 10) * 10;
            pass /= 10;
            matchFound = false;
            counter = 0;
            while (!matchFound)
            {
                gearDigit = gearsInt[gearCount - index] - (gearsInt[gearCount - index] / 10) * 10;
                if (gearDigit != pasDigit)
                    counter++;
                else
                {
                    if (8 - counter < counter)
                    {
                        counter = 8 - counter;
                    }
                    else
                        counter++;
                    moveCount += counter;
                    matchFound = true;
                }
                gearsInt[gearCount - index] /= 10;

            }
        }
        print(moveCount);
    }
    #endregion
}
