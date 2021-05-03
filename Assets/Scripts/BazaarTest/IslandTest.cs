using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IslandTest : MonoBehaviour
{
    #region Varibales
    int[,] mInput;
    #endregion
    #region Functions
    [ContextMenu("Run")]
    public void Run()
    {
        maxPos maxPair = new maxPos();
        mInput = new int[,] { { 0, 1, 4, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 2, 0, 1, 0 }, { 0, 0, 0, 1, 0 }, { 0, 5, 0, 0, 0 } };
        List<int> set = new List<int>();

        for (int i = 0; i < mInput.GetLength(0); i++)
        {
            for (int j = 0; j < mInput.GetLength(1); j++)
            {
                set = new List<int>();
                set.Add(i * mInput.GetLength(0) + j);
                if (mInput[i, j] > 0)
                {
                    search(mInput, set);
                    if (calcValue(mInput,set) > maxPair.value)
                    {
                        maxPair.value = calcValue(mInput,set);
                        maxPair.pos = i * mInput.GetLength(0) + j;
                    }
                }
            }
        }
        print($"MaxPos:{maxPair.pos},MaxTresure:{maxPair.value}");
       
    }
    int calcValue(int[,] array,List<int> set)
    {
        int value = 0;
        for (int i = 0; i < set.Count; i++)
        {
            value += array[set [i]/ array.GetLength(0), set[i] % array.GetLength(0)];
        }
        return value;
    }
    void getNeighbors(ref int[,] array, int index, List<int> relatingIndecies)
    {
        List<int> neighbors = new List<int>();
        int initIndexHoriz = index / array.GetLength(0) > 0 ? index / array.GetLength(0) - 1 : 0;
        int lastIndexHoriz = index / array.GetLength(0) < array.GetLength(0)-1 ? index / array.GetLength(0) + 1 : index / array.GetLength(0);
        int initIndexVert = index % array.GetLength(0) > 0 ? index % array.GetLength(0) - 1 : 0;
        int lastIndexVert = index % array.GetLength(0) < array.GetLength(1)-1 ? index % array.GetLength(0) + 1 : index % array.GetLength(0);
        for (int i = initIndexHoriz; i <= lastIndexHoriz; i++)
        {
            for (int j = initIndexVert; j <= lastIndexVert; j++)
            {
                if (array[i, j] > 0)
                {
                   if (!relatingIndecies.Contains(i * array.GetLength(0) + j))
                    {
                        relatingIndecies.Add(i * array.GetLength(0) + j);
                    }
                }
            }
        }
    }

    void search( int[,] array, List<int> checkList)
    {
        bool isSearchFinished = false;
        int countBefore= checkList.Count;
        while (!isSearchFinished)
        {
            countBefore = checkList.Count;
            for (int i = 0; i < checkList.Count; i++)
            {
                getNeighbors(ref array, checkList[i], checkList);
            }
            if (countBefore == checkList.Count)
                isSearchFinished = true;
        }
    }
    public void test(GameObject a)
    {
        a.transform.position += Vector3.one;
    }
    #endregion
    #region localclasses
    [System.Serializable]
    public class maxPos
    {
        public int pos;
        public int value;
    }
    #endregion
}
