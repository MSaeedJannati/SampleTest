using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class PeakFinder1D : MonoBehaviour
{
    #region Variables
    [SerializeField] int numCount;
    [SerializeField] Object textAsset;
    int[] dataArray;
    #endregion
    #region Naughty buttons
    [NaughtyAttributes.Button]
    public void Run()
    {
        dataArray = parseInput();
        findAPeak();
        //printArray(ref dataArray);

    }
    [NaughtyAttributes.Button]
    public void Create1DNums()
    {
        string data = string.Empty;
        int sampleNum = 0;
        for (int i = 0; i < numCount - 1; i++)
        {
            sampleNum = Random.Range(-2000, 2000);
            data += $"{sampleNum},";
        }
        sampleNum = Random.Range(-2000, 2000);
        data += sampleNum.ToString();
        FileCreator.createFIle("1DSampleInput", data);

    }
    #endregion
    #region Functions
    public int[] parseInput()
    {
        string[] rawInput = textAsset.ToString().Split(',');
        int[] outputData = new int[rawInput.Length];
        for (int i = 0; i < outputData.Length; i++)
        {
            int.TryParse(rawInput[i], out outputData[i]);
        }
        return outputData;
    }
    public void printArray(ref int[] inputArray)
    {
        FileCreator.createFIle("1DArryJson", JsonConvert.SerializeObject(inputArray));
    }
    public void findAPeak()
    {
        int result = -2;
        int currentIndex = dataArray.Length / 2;
        while (result != 0)
        {
            result = checkIfPeak(currentIndex);
            switch (result)
            {
                case -1:
                    currentIndex = currentIndex / 2;
                    break;
                case 1:
                    currentIndex += (dataArray.Length - currentIndex) / 2;
                    break;
            }
        }

        print($"Index:{currentIndex},Result:{result}");
        //StartCoroutine(findAPeakCoroutine());
    }
    public int checkIfPeak(int index)
    {
        if (index == 0)
        {
            if (dataArray[index] >= dataArray[index + 1])
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        if (index == dataArray.Length - 1)
        {
            if (dataArray[index] >= dataArray[index - 1])
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        if (dataArray[index] >= dataArray[index + 1] && dataArray[index] >= dataArray[index - 1])
        {
            return 0;
        }
        else if (dataArray[index] <= dataArray[index + 1])
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
    #endregion
    public IEnumerator findAPeakCoroutine()
    {
        int result = -2;
        int currentIndex = dataArray.Length / 2;
        while (result != 0)
        {
            result = checkIfPeak(currentIndex);
            switch (result)
            {
                case -1:
                    currentIndex = currentIndex / 2;
                    break;
                case 1:
                    currentIndex += (dataArray.Length - currentIndex) / 2;
                    break;
            }

            yield return null;
        }

        print($"Index:{currentIndex},Result:{result}");
    }
}
