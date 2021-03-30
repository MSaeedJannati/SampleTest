using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopTeams : MonoBehaviour
{
    #region Variables
   [SerializeField] Object citiesText;
    #endregion
    #region NaughtyAttributes
    [NaughtyAttributes.Button]
    public void Run()
    {
        int[] rich = new int[3];
        int[] poor = new int[3];
        parseData(ref rich, ref poor);
    }
    #endregion
    #region Functions
    void parseData(ref int[] rich, ref int[] poor)
    {
        int cityIndex = 0;
        char[] array = citiesText.ToString().ToCharArray();
        string str = string.Empty;
        int posibleTeamCount = 0;
        for (int i = 0; i < array.Length; i++)
        {
            str = array[i].ToString();
            if (rich[cityIndex] == 0)
            {
                int.TryParse(str, out rich[cityIndex]);
            }
            else if (poor[cityIndex] == 0)
            {
                int.TryParse(str, out poor[cityIndex]);
            }
            else if (array[i]=='\n')
            {
                posibleTeamCount += rich[cityIndex] > poor[cityIndex] ? poor[cityIndex] : rich[cityIndex];
               
            
                cityIndex++;
            }
        }
        posibleTeamCount += rich[cityIndex] > poor[cityIndex] ? poor[cityIndex] : rich[cityIndex];
        print($"team:{posibleTeamCount}");
    }
    #endregion
}
