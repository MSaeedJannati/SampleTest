using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class MergeSort : MonoBehaviour
{
    #region variables
    #endregion
    #region Context menu items
    [ContextMenu("Run the Test")]
    void Run()
    {
        int[] array = createRandomArray(120);
        print(JsonConvert.SerializeObject(array));
        array = RecersiveSort(array);
        print(JsonConvert.SerializeObject(array));
    }
    #endregion
    #region Functions
    public List<int[]> splitArray(int[] array)
    {
        int[] firstArray = new int[array.Length / 2];
        int[] secondArray = new int[array.Length - array.Length / 2];
        for (int i = 0; i < array.Length / 2; i++)
        {
            firstArray[i] = array[i];
        }
        for (int i = array.Length / 2; i < array.Length; i++)
        {
            secondArray[i - array.Length / 2] = array[i];
        }
        List<int[]> splitedArrays = new List<int[]>(2);
        splitedArrays.Add(firstArray);
        splitedArrays.Add(secondArray);
        return splitedArrays;
    }
    public int[] mergeArrays(int[] firstArray,int[] secondArray)
    {
        int firstPointer = 0;
        int secondPointer = 0;
        int chosenAmount = 0;
        int[] sorterdMerge = new int[firstArray.Length + secondArray.Length];
        for (int i = 0; i < sorterdMerge.Length; i++)
        {
            if (firstPointer > firstArray.Length - 1)
            {
                chosenAmount = secondArray[secondPointer];
                secondPointer++;
            }
            else if (secondPointer > secondArray.Length - 1)
            {
                chosenAmount = firstArray[firstPointer];
                firstPointer++;
            }
            else
            {
                if (firstArray[firstPointer] <= secondArray[secondPointer])
                {
                    chosenAmount = firstArray[firstPointer];
                    firstPointer++;
                }
                else
                {
                    chosenAmount = secondArray[secondPointer];
                    secondPointer++;
                }
            }
            sorterdMerge[i] = chosenAmount;
        }
        return sorterdMerge;
    }

    public int[] RecersiveSort(int[] array)
    {
        if (array.Length > 1)
        {
            var splitedArray = splitArray(array);
            return mergeArrays(RecersiveSort(splitedArray[0]), RecersiveSort(splitedArray[1]));
        }
        else
        {
            return array;
        }
    }

    public int[] createRandomArray(int length)
    {
        int[] randomArray = new int[length];
        for (int i = 0; i < length; i++)
        {
            randomArray[i] = Random.Range(-2000,2000);
        }
        return randomArray;
    }
    #endregion
}
