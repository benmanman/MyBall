using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] string playerName = "PlayerName";
    [SerializeField] int level = 0;
    [SerializeField] int coin = 0;
    [SerializeField] int[] testlevel = { 1, 2, 3, 4, 5 };
    const string PLAYER_DATA_KEY = "PlayerData";
    const string PLAYER_DATA_FILE_NAME = "PlayerData.sav";


    [System.Serializable]class SaveData
    {
        public string playerName;
        public int playerLevel;
        public int playerCoin;
        public int[] myint= { 6,7,8};
    }



    public void Save()
    {
        SaveByJson();
    }

    public void Load()
    {
        
        LoadFromJson();
    }

    void SetData(SaveData _data)
    {
        _data.myint[2] = 10;
    }

    void SaveByJson()
    {
        SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME, SavingData());
    }

    void LoadFromJson()
    {
        var saveData = SaveSystem.LoadFromJson<SaveData>(PLAYER_DATA_FILE_NAME);
        loadData(saveData);
        SetData(saveData);
    }

    // 声明一个data class ，然后把各个变量进行复制并返回class类型
    SaveData SavingData()
    {
        var saveData = new SaveData();

        saveData.playerName = playerName;
        saveData.playerLevel = level;
        saveData.playerCoin = coin;
        saveData.myint = testlevel;
        return saveData;
    }

    void loadData(SaveData saveData)
    {
        playerName = saveData.playerName;
        level = saveData.playerLevel;
        coin = saveData.playerCoin;
        testlevel = saveData.myint;
    }


}
