using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParanthesisChecker : MonoBehaviour
{
    #region Variables
    [SerializeField] string Input1;
    [SerializeField] string Input2;
    [SerializeField] string Input3;
    [SerializeField] string Input4;


    #endregion
    #region Naughty buttons
    //[NaughtyAttributes.Button]
    public void Run()
    {
        print(Input1);
        bool isValid = CheckIfValid(Input2);
        if (isValid)
        {
            print("Valid string!");
        }
        else
        {
            print("Invalid!");
        }
    }
    #endregion
    #region Functions
    public bool CheckIfValid(string data)
    {
        int prantesisCount = 0;
        int bracketCount = 0;
        int acoladCount = 0;
        sign lastSignOpened = new sign();
        bool hasEncounteredSign = false;
        char[] dataInCharArray = data.ToCharArray();
        for (int i = 0; i < dataInCharArray.Length; i++)
        {
            switch (dataInCharArray[i])
            {
                case '{':
                    if (!hasEncounteredSign)
                    {
                        hasEncounteredSign = true;
                    }
                    lastSignOpened = sign.ACOLAD;
                    acoladCount++;
                    break;
                case '}':
                    acoladCount--;
                    if (hasEncounteredSign)
                    {
                        if (lastSignOpened != sign.ACOLAD)
                        {
                            if (acoladCount > 0)
                            {
                                return false;
                            }
                        }
                    }

                    break;
                case '(':
                    prantesisCount++;
                    if (!hasEncounteredSign)
                    {
                        hasEncounteredSign = true;
                    }
                    lastSignOpened = sign.PRANTESIS;
                    break;
                case ')':
                    prantesisCount--;
                    if (hasEncounteredSign)
                    {
                        if (lastSignOpened != sign.PRANTESIS)
                        {
                            if (prantesisCount > 0)
                            {
                                return false;
                            }
                        }
                    }
                    break;
                case '[':
                    bracketCount++;
                    if (!hasEncounteredSign)
                    {
                        hasEncounteredSign = true;
                    }
                    lastSignOpened = sign.BRACKET;
                    break;
                case ']':
                    bracketCount--;
                    if (hasEncounteredSign)
                    {
                        if (lastSignOpened != sign.BRACKET)
                        {
                            if (bracketCount > 0)
                            {
                                return false;
                            }
                        }
                    }

                    break;
            }

        }
        if (prantesisCount != 0 || bracketCount != 0 || acoladCount != 0)
        {
            print($"P:{prantesisCount},B:{bracketCount},A:{acoladCount}");
            return false;
        }
        else
        {
            return true;
        }
    }
    
    #endregion
    #region enums
    public enum sign
    {
        PRANTESIS,
        BRACKET,
        ACOLAD
    }
    #endregion
}
