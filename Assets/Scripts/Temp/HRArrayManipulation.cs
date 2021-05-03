using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HRArrayManipulation : MonoBehaviour
{
    static long arrayManipulation(int n, int[][] queries)
    {
        int[] data = new int[n];
        int max = 0;
        int delta = 0;
        for (int i = 0; i < queries.GetLength(0); i++)
        {
            delta = queries[i][2];
            for (int j = queries[i][0] - 1; j < queries[i][1]; j++)
            {
                data[j] += delta;
                if (data[j] > max)
                {
                    max = data[j];
                }
            }
        }

        return max;
    }
}
