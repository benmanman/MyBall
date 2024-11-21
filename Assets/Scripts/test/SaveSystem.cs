using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
   /* public static void SavePlayerPrefabs(string key, object data)
    {
        var json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }*/

    public static void SaveByJson(string saveFileName, object data)
    {
        var json = JsonUtility.ToJson(data);
        Debug.Log("save json:"+json);
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            File.WriteAllText(path, json);
            Debug.Log("保存成功" + json);
        }
        catch (System.Exception exception)
        {
            Debug.LogError($"Failed to save data to {path}.\n{exception}");
        }
    }

    public static T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        try
        {
            if (!File.Exists(path))
            {
                File.Create(path + saveFileName);
                Debug.Log("路径不存在，已创建新的");
            }
            var json = File.ReadAllText(path);
            Debug.Log("拿到 json啦:" + json);
            var data = JsonUtility.FromJson<T>(json);
            return data;

        }
       catch (System.Exception exception)
        {
            //Debug.LogError($"Failed to load data to {path}.\n{exception}");
            return default;
        }
    }

    public static void DeleteSaveFile(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            File.Delete(path);
            Debug.Log("文件删除成功");
        }
        catch(System.Exception exception)
        {
            Debug.LogError($"Failed to dete data to {path}.\n{exception}");
        }
    }
}


