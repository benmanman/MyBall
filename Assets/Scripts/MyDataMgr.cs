using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyDataMgr : MonoBehaviour
{
    [SerializeField] string playerName = "PlayerName";//用户名字
    [SerializeField] int[] levels;//用户所有关卡的通关信息，0 是未通过，1 是已通过
    [SerializeField] int coin = 0;//用户金币
    [SerializeField] int[] stars;//用户每个关卡对应的星星数

    const string MY_PLAYER_DATA_FILE_NAME = "MyPlayerData.blue";

    [System.Serializable]
    class SaveMyUserData
    {
        public string _playerName;
        public int[] _playerLevel;
        public int _playerCoin;
        public int[] _playStar;
    }

    //对外展示的存储函数
    public void Save()
    {
        SaveByJson();
    }

    //对外展示的读数据函数
    public void Load()
    {

        LoadFromJson();
    }


    void SaveByJson()
    {
        SaveSystem.SaveByJson(MY_PLAYER_DATA_FILE_NAME, SavingData());
    }

    void LoadFromJson()
    {
        var saveData = SaveSystem.LoadFromJson<SaveMyUserData>(MY_PLAYER_DATA_FILE_NAME);
        loadData(saveData);
    }

    // 声明一个data class ，然后把各个变量进行复制并返回class类型
    SaveMyUserData SavingData()
    {
        var PlayerData = new SaveMyUserData();

        PlayerData._playerName = playerName;
        PlayerData._playerLevel = levels;
        PlayerData._playerCoin = coin;
        PlayerData._playStar = stars;
        return PlayerData;
    }

    void loadData(SaveMyUserData PlayerData)
    {
        playerName = PlayerData._playerName;
        levels = PlayerData._playerLevel;
        coin = PlayerData._playerCoin;
        stars = PlayerData._playStar;
    }


}
