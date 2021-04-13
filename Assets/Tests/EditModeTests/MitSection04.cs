using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MitSection04
    {
        [Test]
        public void HeapSortCreateRandomList()
        {
            GameObject go = new GameObject();
            HeapSort hs = go.AddComponent<HeapSort>();
            List<int> createdList = hs.createRandomList(12);
            Assert.AreEqual(12, createdList.Count);
        }
        [Test]
        public void HeapSortMaxheapifyChangeNeeded()
        {
            GameObject go = new GameObject();
            HeapSort hs = go.AddComponent<HeapSort>();
            List<int> heap = new List<int> { 1, 2, 3 };
            Assert.AreEqual(2, hs.maxHeapify(ref heap, 0));
        }
        [Test]
        public void HeapSortMaxheapifyNoChangeNeeded()
        {
            GameObject go = new GameObject();
            HeapSort hs = go.AddComponent<HeapSort>();
            List<int> heap = new List<int> { 3, 2, 1 };
            Assert.AreEqual(-1, hs.maxHeapify(ref heap, 0));
        }
        [Test]
        public void HeapSortCreateMaxHeapBinaryTree()
        {
            GameObject go = new GameObject();
            HeapSort hs = go.AddComponent<HeapSort>();
            List<int> Heap = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<int> maxHeap = new List<int> { 6, 5, 3, 4, 2, 1 };
            hs.createMaxHeapBinaryTree(ref Heap);
            for (int i = 0; i < Heap.Count; i++)
            {
                Assert.AreEqual(maxHeap[i], Heap[i]);
            }
        }
        [Test]
        public void HeapSortExtractTheShorten()
        {
            GameObject go = new GameObject();
            HeapSort hs = go.AddComponent<HeapSort>();
            List<int> maxHeapInit = new List<int> { 6, 5, 3, 4, 2, 1 };
            List<int> maxHeapDest = new List<int> { 5, 4, 3, 1, 2 };
            int extractedValue = hs.extractThenShorten(ref maxHeapInit);
            Assert.AreEqual(6, extractedValue, "Max should be 6");
            for (int i = 0; i < maxHeapDest.Count; i++)
            {
                Assert.AreEqual(maxHeapDest[i], maxHeapInit[i], $"Index{i}has incorrect value");
            }
        }
        [Test]
        public void HeapSortMaxHeapifyToBottom()
        {
            GameObject go = new GameObject();
            HeapSort hs = go.AddComponent<HeapSort>();
            List<int> heap = new List<int> { 1, 5, 3, 4, 2 };
            List<int> maxHeap = new List<int> { 5, 4, 3, 1, 2 };
            hs.MaxHeapifyToBottom(ref heap, 0);
            for (int i = 0; i < heap.Count; i++)
            {
                Assert.AreEqual(maxHeap[i], heap[i], $"Index {i} has incorrect value ");
            }

        }
        [Test]
        public void HeapSortSwap()
        {
            GameObject go = new GameObject();
            HeapSort hs = go.AddComponent<HeapSort>();
            List<int> set = new List<int> { 1, 2, 3, 4, 5 };
            hs.swap(ref set, 1, 3);
            Assert.AreEqual(4, set[1]);
            Assert.AreEqual(2, set[3]);
        }
        [Test]
        public void HeapSortCreateSortedList()
        {
            GameObject go = new GameObject();
            HeapSort hs = go.AddComponent<HeapSort>();
            List<int> initList = new List<int> { 2, 1, 4, 5, 3, 6 };
            List<int> sortedList = new List<int> { 1, 2, 3, 4, 5, 6 };
            hs.createMaxHeapBinaryTree(ref initList);
            hs.createSortedList(ref initList);
            for (int i = 0; i < sortedList.Count; i++)
            {
                Assert.AreEqual(sortedList[i], initList[i]);
            }
        }
    }
}
