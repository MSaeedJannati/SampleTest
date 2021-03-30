using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
namespace SampleProject.MitCourse
{
    public class PeakFinder2D : MonoBehaviour
    {
        #region Variables
        int[,] inputData;

        #endregion
        #region Naughty Buttons
        [NaughtyAttributes.Button]
        public void fillInputDataRandomly()
        {
            int rowCount = Random.Range(50, 100);
            int coloumnCount = Random.Range(50, 100);
            inputData = new int[rowCount, coloumnCount];
            for (int i = 0; i < inputData.GetLength(0); i++)
            {
                for (int j = 0; j < inputData.GetLength(1); j++)
                {
                    inputData[i, j] = Random.Range(-10000, 10000);
                }
            }
            FileCreator.createFIle("PeakFinder2dInput", JsonConvert.SerializeObject(inputData));
        }
        [NaughtyAttributes.Button]
        public void Run()
        {
            fillInputDataRandomly();
            FindAPeak();
        }
        #endregion
        #region Functions
        public void FindAPeak()
        {
            bool peakFound = false;
            int coloumnToCheck = inputData.GetLength(1) / 2;
           
            while (!peakFound)
            {
                switch(isPeak(findMaxIndex(coloumnToCheck), coloumnToCheck))
                {
                    case 0:
                        peakFound = true;
                        print($"Row:{findMaxIndex(coloumnToCheck)},Col:{coloumnToCheck}");
                        break;
                    case 1:
                        coloumnToCheck += (inputData.GetLength(1) - coloumnToCheck) / 2;
                        break;
                    case -1:
                        coloumnToCheck -= (inputData.GetLength(1) - coloumnToCheck) / 2;
                        break;
                }
            }
        }
        public int findMaxIndex(int coloumnIndex)
        {
            int maxIndex = 0;
            for (int i = 0; i < inputData.GetLength(0); i++)
            {
                if (inputData[i, coloumnIndex]>= inputData[maxIndex, coloumnIndex])
                {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
        public int isPeak(int rowIndex, int coloumnIndex)
        {
            if (coloumnIndex == 0)
            {
                if (inputData[rowIndex, coloumnIndex] >= inputData[rowIndex, coloumnIndex+1])
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
                    
            }
            if (coloumnIndex == inputData.GetLength(1)-1)
            {
                if (inputData[rowIndex, coloumnIndex] >= inputData[rowIndex, coloumnIndex-1])
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }

            if (inputData[rowIndex, coloumnIndex] < inputData[rowIndex, coloumnIndex + 1])
            {
                return 1;
            }
            else if (inputData[rowIndex, coloumnIndex] < inputData[rowIndex, coloumnIndex - 1])
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }
}
