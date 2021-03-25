using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhromeSabzi : MonoBehaviour
{
    #region Variables
    [SerializeField] Object inputText;


    
    #endregion
    #region NaughtyAttribute buttons
    [NaughtyAttributes.Button]
    public void Run()
    {
        ParseData();
    }
    #endregion

    #region Fucntions
    void ParseData()
    {
        char[] charArray = inputText.ToString().ToCharArray();
        int lineIndex = 0;
        int row = 0;
        int coloumn = 0;

        int[] containerMeatCount = new int[2];
        
        for (int i = 0; i < charArray.Length; i++)
        {
            if (charArray[i] == '\n')
                lineIndex++;
            CheckForRowAnColoumn(charArray[i].ToString(), lineIndex, ref row, ref coloumn);
            if (lineIndex>0)
            {
                if (lineIndex <= row)
                {
                    if (charArray[i] == '*')
                    {
                        containerMeatCount[0]++;
                    }
                }
                else
                {
                    if (charArray[i] == '*')
                    {
                        containerMeatCount[1]++;
                    }
                }
            }
        }
        print($"FirstContainer:{containerMeatCount[0]},secondContainer:{containerMeatCount[1]}");
    }
    public void CheckForRowAnColoumn(string str,int lineIndex,ref int row,ref int coloumn)
    {
        if (lineIndex == 0)
        {
            if (row == 0)
            {
                int.TryParse(str, out row);
            }
            else if (coloumn == 0)
            {
                int.TryParse(str, out coloumn);
            }
        }
    }
    #endregion
}
