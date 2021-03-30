using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextComparison : MonoBehaviour
{
    #region Variables
    [ContextMenuItem("RunTheComparison", nameof(Run))]
    [SerializeField] string firstFileName;
    [SerializeField] string secondFileName;
    #endregion
    #region properties
    #endregion
    #region NaughtyAttributes
    //[NaughtyAttributes.Button]
    [ContextMenu("RunTheComparison")]
    public void Run()
    {
        var fileInput = ReadFiles(firstFileName, secondFileName);
        var fileWords = fillTheDictionaries(ref fileInput);
        float cos = calcDotProduct(ref fileWords);
        print($"Cos:{cos},Angle:{Mathf.Acos(cos) * 180 / Mathf.PI}");
        //createFiles();
    }
    #endregion
    #region Functions
    public string[] ReadFiles(string FirstFileName, string SecondFileName)
    {
        var fileInput = new string[2];
        fileInput[0] = FileCreator.readFile(FirstFileName);
        fileInput[1] = FileCreator.readFile(SecondFileName);
        return fileInput;
    }
    public Dictionary<string, int>[] fillTheDictionaries(ref string[] fileInput)
    {
        var fileWords = new Dictionary<string, int>[2];
        fileWords[0] = new Dictionary<string, int>();
        fileWords[1] = new Dictionary<string, int>();
        for (int i = 0; i < fileWords.Length; i++)
        {
            string[] words = fileInput[i].Split(' ');
            fileWords[i] = new Dictionary<string, int>(words.Length);
            for (int j = 0; j < words.Length; j++)
            {
                if (fileWords[i].ContainsKey(words[j]))
                {
                    fileWords[i][words[j]]++;
                }
                else
                {
                    fileWords[i].Add(words[j], 1);
                }
            }
        }
        return fileWords;
    }
    public float calcDotProduct(ref Dictionary<string, int>[] dicts)
    {
        float cos = calcDotNuminator(ref dicts) / calcDictSize(ref dicts[0]) / calcDictSize(ref dicts[1]);
        return cos;

    }
    public float calcDictSize(ref Dictionary<string, int> dict)
    {
        float value = 0.0f;
        foreach (var pair in dict)
        {
            value += pair.Value * pair.Value;
        }
        return Mathf.Sqrt(value);
    }
    public float calcDotNuminator(ref Dictionary<string, int>[] dicts)
    {
        float value = 0.0f;
        foreach (var pair in dicts[0])
        {
            if (dicts[1].ContainsKey(pair.Key))
            {
                value += pair.Value * dicts[1][pair.Key];
            }
        }
        return value;
    }
    public void createFiles()
    {
        FileCreator.createFIle(firstFileName, "hello naughty black dog");
        //FileCreator.createFIle(firstFileName, "bye calm green dog");
        FileCreator.createFIle(secondFileName, "hello naughty black cat");
    }
    #endregion
}
