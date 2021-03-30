using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MitSection03Tests
    {
        #region InsertionSort tests
        [Test]
        public void InsertionSortCreateRandomArrayLengthCheck()
        {
            GameObject go = new GameObject();
            var IS = go.AddComponent<InsertionSort>();
            int[] array = IS.creatRandomArray(12);
            Assert.AreEqual(12, array.Length);
        }
        [Test]
        public void InsertionSortBinarySearchForProperIndexTestMidPos()
        {
            GameObject go = new GameObject();
            var IS = go.AddComponent<InsertionSort>();
            int[] array = { -12, -10, -8, 1, 2, 12, -9 };
            Assert.AreEqual(2,IS.binarySaerchForProperIndex(ref array, 6));
        }
        [Test]
        public void InsertionSortBinarySearchForProperIndexTestStartPos()
        {
            GameObject go = new GameObject();
            var IS = go.AddComponent<InsertionSort>();
            int[] array = { -12, -10, -8, 1, 2, 12, -9 };
            Assert.AreEqual(0,IS.binarySaerchForProperIndex(ref array, 0));
        }
        [Test]
        public void InsertionSortBinarySearchForProperIndexTestEndPos()
        {
            GameObject go = new GameObject();
            var IS = go.AddComponent<InsertionSort>();
            int[] array = { -12, -10, -8, 1, 2, 12, 14, 15 };
            Assert.AreEqual(7,IS.binarySaerchForProperIndex(ref array, 7));
        }
        [Test]
        public void InsertionSortIsProperPlaceRight()
        {
            GameObject go = new GameObject();
            var IS = go.AddComponent<InsertionSort>();
            int[] array = { -12, -10, -8, 1, 2, 12, -9 };
            int result = IS.isProperPlace(ref array, 1, 6);
            Assert.AreEqual( 1,result);
        }
        [Test]
        public void InsertionSortIsProperPlaceLeft()
        {
            GameObject go = new GameObject();
            var IS = go.AddComponent<InsertionSort>();
            int[] array = { -12, -10, -8, 1, 2, 12, -9 };
            int result = IS.isProperPlace(ref array, 5, 6);
            Assert.AreEqual(  result, -1);
        }
        [Test]
        public void InsertionSortIsProperPlaceCorrectPos()
        {
            GameObject go = new GameObject();
            var IS = go.AddComponent<InsertionSort>();
            int[] array = { -12, -10, -8, 1, 2, 12, -9 };
            int result = IS.isProperPlace(ref array, 2, 6);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void InsertionSortSwap()
        {
            GameObject go = new GameObject();
            var IS = go.AddComponent<InsertionSort>();
            int[] array = { -12, -10, -8, 1, 2, 12, -9 };
            IS.swap(ref array,2,5);
            Assert.AreEqual(12,array[2] );
            Assert.AreEqual(-8, array[5]);
        }
        [Test]
        public void InsertionSortSort()
        {
            GameObject go = new GameObject();
            var IS = go.AddComponent<InsertionSort>();
            int[] array = { 6, 3, 4, 7, 1, 9, 8,10,2,5 };
            int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IS.sort(ref array);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(sortedArray[i], array[i]);
            }
        }
        #endregion
        #region MergeSort tests
        [Test]
        public void MergeSortSplitArrayTest()
        {
            GameObject go = new GameObject();
            MergeSort ms = go.AddComponent<MergeSort>();
            int[] array= { 1, 2, 3, 4, 5 };
            int[] firstArray = { 1, 2 };
            int[] secondArray = { 3,4,5};
            List<int[]> splitedArrays = ms.splitArray(array);
            for (int i = 0; i < splitedArrays[0].Length; i++)
            {
                Assert.AreEqual(firstArray[i], splitedArrays[0][i]);
            }
            for (int i = 0; i < splitedArrays[1].Length; i++)
            {
                Assert.AreEqual(secondArray[i], splitedArrays[1][i]);
            }
        }
        [Test]
        public void MergeSortMergeArraysTest()
        {
            GameObject go = new GameObject();
            MergeSort ms = go.AddComponent<MergeSort>();
            int[] mergedArray = { 1, 2, 3, 4, 5, 6, 7 };
            int[] firstArray = { 1, 4, 5 };
            int[] secondArray = { 2, 3, 6, 7 };
            int[] outPutArray = ms.mergeArrays(firstArray, secondArray);
            for (int i = 0; i < mergedArray.Length; i++)
            {
                Assert.AreEqual(mergedArray[i], outPutArray[i]);
            }
        }
        [Test]
        public void MergeSortRecersiveSort()
        {
            GameObject go = new GameObject();
            MergeSort ms = go.AddComponent<MergeSort>();
            int[] inputArray = { 9, 5, 1, 2, 8, 3, 7, 4, 6 };
            int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            inputArray = ms.RecersiveSort(inputArray);
            for (int i = 0; i < inputArray.Length; i++)
            {
                Assert.AreEqual(sortedArray[i],inputArray[i]);
            }
        }
        #endregion

    }
}
