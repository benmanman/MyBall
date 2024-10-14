using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    private System.Random r;

    [SerializeField] public string playerName = "PlayerName";//用户名字
    [SerializeField] public int[] levelPass= new int[100];//用户所有关卡的通关信息，0 是未通过，1 是已通过
    [SerializeField] public int coin = 0;//用户金币
    [SerializeField] public int[] starNum = new int[100];//用户每个关卡对应的星星数
    [SerializeField] public int currentLevel = 0;//用户金币


    const string MY_PLAYER_DATA_FILE_NAME = "MyPlayerData.blue";

    [System.Serializable]
    class SaveMyUserData
    {
        public string _playerName;
        public int[] _playerLevel;
        public int _playerCoin;
        public int[] _playStar;
        public int _currentLevel;
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
        PlayerData._playerLevel = levelPass;
        PlayerData._playerCoin = coin;
        PlayerData._playStar = starNum;
        PlayerData._currentLevel = currentLevel;
        return PlayerData;
    }

    void loadData(SaveMyUserData PlayerData)
    {
        playerName = PlayerData._playerName;
        levelPass = PlayerData._playerLevel;
        coin = PlayerData._playerCoin;
        starNum = PlayerData._playStar;
        currentLevel = PlayerData._currentLevel;
        Debug.Log("chengg load");
    }

    // Start is called before the first frame update
    void Start()
    {
       // InitialUserData();
        /*
        r = new System.Random();
        for (int i=0; i < 13; i++)
        {
            
            levelPass[i] = 1;//造个数据，前 27 关已过
            starNum[i] = r.Next(0, 3);
        }
        currentLevel = 5;
        */
        //start的时候需要读取保存在本地的关卡数据
    }


    //因为生成的物体会从左到右，但是关卡是 S 型的，所以需要转化一下生成真是的关卡
    public int GetRealLevel(int _level)
    {
        if (_level % 10 < 5)
        {
            return _level+1;
        }
        else
        {
            int n = (int)Math.Ceiling(_level / 10.00);
            int realLevel = n * 10 - (_level % 5);
            return realLevel;
        }
    }

    //初始化,当用户是新用户时，我们调用初始化数据
    void InitialUserData()
    {
        playerName = "New User Blue";
        levelPass[0] = 1;
        starNum[0] = 0;
        currentLevel = 1;
        coin = 0;
        for (int i=1; i < 100; i++)
        {
            levelPass[i] = 0;
            starNum[i] = 0;
        }
        Save();
    }

    //设置所有值
    public void SetCoin(int _coin)
    {
        coin = _coin;
        Save();
    }
    //当前通过的关卡、通过关卡的星星、下一个关卡开启
    public void SetLevel_Star(int _level, int _star)
    {
        levelPass[_level] = 1;
        starNum[_level] = _star;
        Save();
    }
    public void SetName(string _name)
    {
        playerName = _name;
        Save();
    }

    

}
