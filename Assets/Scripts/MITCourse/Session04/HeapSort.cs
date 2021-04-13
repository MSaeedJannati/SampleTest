using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class HeapSort : MonoBehaviour
{
    #region Variables
    #endregion
    #region Functions
    [ContextMenu("Run")]
    public void Run()
    {
        List<int> list = createRandomList(20);
        print(JsonConvert.SerializeObject(list));
        createMaxHeapBinaryTree(ref list);
        createSortedList(ref list);
        print(JsonConvert.SerializeObject(list));

    }
    public List<int> createRandomList(int length)
    {
        List<int> list = new List<int>(length);
        for (int i = 0; i < length; i++)
        {
            list.Add(Random.Range(-2000, 2000));
        }
        return list;
    }
    public int maxHeapify(ref List<int> array, int index)
    {
        
        int maxIndex = index;
        if (2 * index + 1 < array.Count)
        {
            if (array[2 * index + 1] > array[index])
            {
                maxIndex = 2 * index + 1;
            }
        }
        if (2 * index + 2 < array.Count)
        {
            if (array[2 * index + 2] > array[maxIndex])
            {
                maxIndex = 2 * index + 2;
            }
        }
        if (maxIndex != index)
        {
            swap(ref array, index, maxIndex);
            MaxHeapifyToBottom(ref array,maxIndex);
            return maxIndex;
        }
        return -1;
    }
    public void createMaxHeapBinaryTree(ref List<int> array)
    {
        for (int i = array.Count / 2 - 1; i >= 0; i--)
        {
            maxHeapify(ref array, i);
        }
    }
    public int extractThenShorten(ref List<int> array)
    {
        int maxValue = array[0];
        swap(ref array, 0, array.Count - 1);
        array.RemoveAt(array.Count - 1);
        MaxHeapifyToBottom(ref array, 0);
        return maxValue;
    }
    public void MaxHeapifyToBottom(ref List<int> array,int index)
    {
        int maxindex = maxHeapify(ref array, index);
        if (maxindex != -1)
        {
            MaxHeapifyToBottom(ref array, maxindex);
        }
    }
    public void swap(ref List<int> array, int firstIndex, int secondIndex)
    {
        int tmpValue = array[firstIndex];
        array[firstIndex] = array[secondIndex];
        array[secondIndex] = tmpValue;
    }
    public void createSortedList(ref List<int> list)
    {
        List<int> tmpList = new List<int>(list.Count);
        int count = list.Count;
        for (int i = 0; i < count; i++)
        {
            int value = extractThenShorten(ref list);
            tmpList.Add(value);
        }
        list = new List<int>();
        for (int i = 0; i < tmpList.Count; i++)
        {
            list.Add(tmpList[i]);
        }
        list.Reverse();
    }
    #endregion
}
