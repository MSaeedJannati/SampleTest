using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace Tests
{
    public class MitSection2Tests
    {
        [Test]
        public void fillTheDictsTestOfDictsLength()
        {
            GameObject go = new GameObject();

            TextComparison tc = go.AddComponent<TextComparison>();
            string[] data = { "Hello lille dog", "yow almighty cat" };
            var dicts = tc.fillTheDictionaries(ref data);
            Assert.AreEqual(2, dicts.Length, "Dict has unexpected length");
            Assert.AreEqual(3, dicts[0].Count, "first dict has unexpected length");
            Assert.AreEqual(3, dicts[1].Count, "first dict has unexpected length");

        }
        [Test]
        public void calcDictSizeTest()
        {
            GameObject go = new GameObject();

            TextComparison tc = go.AddComponent<TextComparison>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("hello", 3);
            dict.Add("world", 4);
            float size = tc.calcDictSize(ref dict);
            Assert.AreEqual(5.0f, size);
        }

        [Test]
        public void calcDotNuminatorTest()
        {
            GameObject go = new GameObject();

            TextComparison tc = go.AddComponent<TextComparison>();
            Dictionary<string, int> dict1 = new Dictionary<string, int>();
            dict1.Add("hello", 3);
            dict1.Add("world", 4);
            Dictionary<string, int> dict2 = new Dictionary<string, int>();
            dict2.Add("hello", 1);
            dict2.Add("nord", 4);
            Dictionary<string, int>[] dicts = { dict1, dict2 };
            float numinator = tc.calcDotNuminator(ref dicts);
            Assert.AreEqual(3, numinator);
        }
        [Test]
        public void calcDotProductTest()
        {
            GameObject go = new GameObject();

            TextComparison tc = go.AddComponent<TextComparison>();
            Dictionary<string, int> dict1 = new Dictionary<string, int>();
            dict1.Add("hello", 3);
            dict1.Add("world", 4);
            Dictionary<string, int> dict2 = new Dictionary<string, int>();
            dict2.Add("hello", 3);
            dict2.Add("nord", 4);
            Dictionary<string, int>[] dicts = { dict1, dict2 };
            float cos = tc.calcDotProduct(ref dicts);
            Assert.AreEqual(9.0f / 25.0f, cos);
        }
    }
}
