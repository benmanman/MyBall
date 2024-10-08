using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [System.Serializable]class TestData
    {
        public bool testBool;
        public int testInt;
        public int[] testArray = { 1, 2, 3 };
        public List<int> testlist = new List<int>() { 4, 5, 6 };
    }

    // Start is called before the first frame update
    void Start()
    {
        var testData = new TestData();
        print(JsonUtility.ToJson(testData));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
