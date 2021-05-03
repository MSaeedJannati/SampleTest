using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingNumbers : MonoBehaviour
{
    [ContextMenu("Run")]
    public void Run()
    {
        List<int> input = new List<int> { 1, 2, 2, 3, 1, 2 };
        print( pickingNumbers(input));

    }
    public  int pickingNumbers(List<int> a)
    {
        Dictionary<int, int> pickingNumbers = new Dictionary<int, int>(a.Count);
        for (int i = 0; i < a.Count; i++)
        {
            if (pickingNumbers.ContainsKey(a[i]))
            {
                pickingNumbers[a[i]]++;
            }
            else
            {
                pickingNumbers.Add(a[i], 1);
            }
        }
        int maxNum = 0;
        int currentnum = 0;
        foreach (var pair in pickingNumbers)
        {
            currentnum = 0;
            if (pair.Value > maxNum)
            {
                maxNum = pair.Value;
            }
            if (pickingNumbers.ContainsKey(pair.Key - 1))
            {
                currentnum = pair.Value + pickingNumbers[pair.Key - 1];
                if (currentnum > maxNum)
                {
                    maxNum = currentnum;
                }
            }
            if (pickingNumbers.ContainsKey(pair.Key + 1))
            {
                currentnum = pair.Value + pickingNumbers[pair.Key + 1];
                if (currentnum > maxNum)
                {
                    maxNum = currentnum;
                }
            }
        }
        return maxNum;
    }
    
}
