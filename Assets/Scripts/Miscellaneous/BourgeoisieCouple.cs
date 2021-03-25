using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
public class BourgeoisieCouple : MonoBehaviour
{
    #region Variables
   
    [SerializeField] string Bourgeoisie;
    [SerializeField] int Count;
    [SerializeField] string fileName;
    int[] capitals;
    //List<int> capitals;
    Stopwatch watch;
    #endregion
    #region NaughtyAttributes
    [NaughtyAttributes.Button]
    public void Test()
    {
        watch = new Stopwatch();
        watch.Restart();
        ParseBourgeoisieString();
        FindPaires();
        watch.Stop();
        print($"Time:{watch.Elapsed}");
    }
    public void CreateFile(ref string data)
    {
        string path = $"F:\\QueraTest\\{fileName}.txt";
        if (File.Exists(path))
            File.Delete(path);
        FileStream file = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.Write(data);
        }
    }
    [NaughtyAttributes.Button]
    public void CreateString()
    {
        string outStr= string.Empty;
        for (int i = 0; i < 20000; i++)
        {
            outStr += Random.Range(-100000, 100000)+",";
        }
        outStr += Random.Range(-100000, 100000);
        CreateFile(ref outStr);
    }
    #endregion
    #region Functions
    public void ParseBourgeoisieString()
    {
        string[] splitedStrings = Bourgeoisie.Split(',');
        capitals = new int[splitedStrings.Length];
        for (int i = 0; i < splitedStrings.Length; i++)
        {
            capitals[i] = int.Parse(splitedStrings[i]);
        }
        //capitals = new List<int>(Bourgeoisie.Length);
        //for (int i = 0; i < splitedStrings.Length; i++)
        //{
        //    capitals.Add(int.Parse(splitedStrings[i]));
        //}
    }
    public void FindPaires()
    {
        int counter = 0;
        int firstOne = 0;
        int SecondOne = 0;
        for (int i = 0; i < capitals.Length - 2; i++)
        {
            for (int j = i+1; j < capitals.Length; j++)
            {
                firstOne = capitals[i];
                SecondOne = capitals[j];
                if (firstOne - SecondOne > firstOne + SecondOne || -firstOne + SecondOne > firstOne + SecondOne)
                {
                    counter++;
                }
            }

        }
        print(counter);
    }

    #endregion
}
