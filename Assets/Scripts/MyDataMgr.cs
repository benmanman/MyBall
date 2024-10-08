using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyDataMgr : MonoBehaviour
{
    public int[] testarray = { 0, 1, 2, 3, 4, 5 };
    public int[] testload;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //存储 int 数组
    public void SaveMyIntArray(int[] array_tobesave, string key)
    {
        string array_json = JsonUtility.ToJson(array_tobesave);
        PlayerPrefs.SetString(key, array_json);
        PlayerPrefs.Save();
    }

    //读取 int 数组
    public void LoadMyIntArray(int[] loadArray, string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key), loadArray);
        }
    }

    //存储 string



}
