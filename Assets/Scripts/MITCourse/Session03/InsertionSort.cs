using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class InsertionSort : MonoBehaviour
{
    #region Variables
    int PROPERINDEX = 0;
    #endregion
    #region ContextMenu functions
    [ContextMenu("run function")]
    public void Run()
    {
        int[] array = creatRandomArray(50);
        print(JsonConvert.SerializeObject(array));
        sort(ref array);
        print(JsonConvert.SerializeObject(array));
    }

    [ContextMenu("TestRun")]
    public void testing()
    {
        int[] array = { 5, 4, 6, 3, 10, 9, 1, 2, 7, 8 };
        StartCoroutine(sort(array));
    }
    #endregion
    #region Functions
    public int[] creatRandomArray(int length)
    {
        int[] inputArray = new int[length];
        for (int i = 0; i < length; i++)
        {
            inputArray[i] = Random.Range(-1000, 1000);
        }
        return inputArray;
    }
    public int binarySaerchForProperIndex(ref int[] array, int currentIndex)
    {
        int properIndex = currentIndex / 2;
        bool found = false;
        int lastTopIndex = currentIndex;
        int lastDownIndex = 0;
        while (!found)
        {
            switch (isProperPlace(ref array, properIndex, currentIndex))
            {
                case 0:
                    found = true;
                    break;
                case 1:
                    lastDownIndex = properIndex;
                    properIndex += ((lastTopIndex - properIndex) / 2) > 0 ? ((lastTopIndex - properIndex) / 2) : 1;

                    break;
                case -1:
                    lastTopIndex = properIndex;
                    properIndex -= ((-lastDownIndex + properIndex) / 2) > 0 ? ((-lastDownIndex + properIndex) / 2) : 1;
                    break;
            }
        }
        return properIndex;
    }
    public int isProperPlace(ref int[] array, int checkingIndex, int currentIndex)
    {
        if (checkingIndex == 0)
        {
            if (array[currentIndex] > array[checkingIndex])
                return 1;
            else
                return 0;
        }
        if (array[currentIndex] > array[checkingIndex])
        {
            return 1;
        }
        else if (array[currentIndex] < array[checkingIndex - 1])
        {
            return -1;
        }
        else
        {
            return 0;
        }

    }
    public void swap(ref int[] array, int firstIndex, int secondIndex)
    {
        int tempInt = array[firstIndex];
        array[firstIndex] = array[secondIndex];
        array[secondIndex] = tempInt;

    }
    public void sort(ref int[] array)
    {
        int properPlace = 0;
        for (int i = 0; i < array.Length; i++)
        {
            properPlace = binarySaerchForProperIndex(ref array, i);
            if (properPlace != i)
            {
                for (int j = i; j > properPlace; j--)
                {
                    swap(ref array, j, j - 1);
                }
            }
        }
    }

    #endregion

    #region Coroutines
    public IEnumerator sort(int[] array)
    {
        //int properPlace = 0;
        for (int i = 0; i < array.Length; i++)
        {
            yield return findProper(array, i);
            if (PROPERINDEX != i)
            {
                for (int j = i; j > PROPERINDEX; j--)
                {
                    swap(ref array, j, j - 1);
                }
            }
        }


        print(JsonConvert.SerializeObject(array));
    }
    public IEnumerator findProper(int[] array, int currentIndex)
    {
        int properIndex = currentIndex / 2;
        bool found = false;

        int lastTopIndex = currentIndex;
        int lastDownIndex = 0;
        print(JsonConvert.SerializeObject(array));
        while (!found)
        {
            switch (isProperPlace(ref array, properIndex, currentIndex))
            {
                case 0:
                    found = true;
                    break;
                case 1:
                    lastDownIndex = properIndex;
                    properIndex += ((lastTopIndex - properIndex) / 2) > 0 ? ((lastTopIndex - properIndex) / 2) : 1;

                    break;
                case -1:
                    lastTopIndex = properIndex;
                    properIndex -= ((-lastDownIndex + properIndex) / 2) > 0 ? ((-lastDownIndex + properIndex) / 2) : 1;
                    break;
            }

            print($"amount:{array[currentIndex]},index:{currentIndex},proper:{properIndex}");
            yield return null;
        }
        PROPERINDEX = properIndex;
        yield break;
    }
    #endregion
}
