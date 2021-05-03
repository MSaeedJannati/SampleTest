using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeConversion : MonoBehaviour
{
    [ContextMenu("TestTheFunction")]
    public void Run()
    {
        string input = "07:05:45PM";
       print( timeConversion(input));
    }
    string timeConversion(string s)
    {
        string[] parts = s.Split(':');
        string outPut = string.Empty;
        int Hours = int.Parse( parts[0]);
        if (parts[parts.Length - 1][parts[parts.Length - 1].Length - 2] == 'P')
        {
            if (Hours < 12)
            {
                Hours += 12;
                outPut += Hours.ToString() + ":";

            }
            else
            {
                outPut += "12:";
            }
        }
        else
        {
            if (Hours == 12)
            {
                outPut += "00:";
            }
            else if (Hours < 10)
            {
                outPut += "0" + Hours.ToString() + ":";
            }
            else
            {
                outPut+= Hours.ToString() + ":";
            }
        }
        return outPut + parts[1] + ":" + parts[2][0]+parts[2][1];

    }
}
