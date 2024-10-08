using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    public static void SavePlayerPrefabs(string key, object data)
    {
        var json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }

    public static string LoadFromJson(string key)
    {
        return PlayerPrefs.GetString(key,null);
    }

    public static void SaveByJson(string saveFileName, object data)
    {
        var json = JsonUtility.ToJson(data);
        Debug.Log("我保存的json:"+json);
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            File.WriteAllText(path, json);

        }
        catch(System.Exception exception)
        {
            Debug.LogError($"Failed to save data to {path}.\n{exception}");
        }
    }

    public static T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);
            return data;

        }
        catch (System.Exception exception)
        {
            Debug.LogError($"Failed to load data to {path}.\n{exception}");
            return default;
        }
    }

    public static void DeleteSaveFile(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            File.Delete(path);
        }
        catch(System.Exception exception)
        {
            Debug.LogError($"Failed to dete data to {path}.\n{exception}");
        }
    }
}


