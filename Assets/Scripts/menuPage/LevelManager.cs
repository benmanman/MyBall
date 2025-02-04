using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class LevelManager
{
    private static System.Random r;

    [SerializeField] public static string playerName = "PlayerName88";//用户名字
    [SerializeField] public static int[] levelPass= new int[30];//用户所有关卡的通关信息，0 是未通过，1 是已通过
    [SerializeField] public static int coin = 0;//用户金币
    [SerializeField] public static int[] starNum = new int[30];//用户每个关卡对应的星星数
    [SerializeField] public static int currentLevel = 0;//用户当前关卡
    [SerializeField] public static bool hasInitial = false;//标记该用户是否被初始化过
    [SerializeField] public static int[] levelTotalScore = { 10, 20, 30, 10, 20, 30, 10, 20, 30, 10, 20, 30, 10, 20, 30, 10, 20, 30, 10, 20, 30, 10, 20, 30, 10, 20, 30, 10, 20, 30};//用户每个关卡满分是多少


    const string MY_PLAYER_DATA_FILE_NAME = "MyPlayerData.blue";

    [System.Serializable]
    public class SaveMyUserData
    {
        public string _playerName;
        public int[] _playerLevel;
        public int _playerCoin;
        public int[] _playStar;
        public int[] _levelTotalScore;
        public int _currentLevel;
        public bool _hasInitial;
        public SaveMyUserData()
        {
            _playerName = "PlayerName66";
            _playerLevel = new int[30];
            _playerCoin = 0;
            _playStar = new int[30];
            _levelTotalScore = new int[] { 10, 20, 30, 10, 20, 30, 10, 20, 30, 10, 20, 30, 10, 20, 30, 10, 20, 30, 10, 20, 30, 10, 20, 30, 10, 20, 30, 10, 20, 30};
            _currentLevel = 1;
            _hasInitial = true;
            _playerLevel[_currentLevel] = 1;
        }
    }

    //对外展示的存储函数
    public static void Save()
    {
        SaveByJson();
    }

    //对外展示的读数据函数
    public static void Load()
    {
        LoadFromJson();
    }

    public static void DeleteData()
    {
        SaveSystem.DeleteSaveFile(MY_PLAYER_DATA_FILE_NAME);
    }


    static void SaveByJson()
    {
        SaveSystem.SaveByJson(MY_PLAYER_DATA_FILE_NAME, SavingData());
    }

    static void LoadFromJson()
    {
        var saveData = SaveSystem.LoadFromJson<SaveMyUserData>(MY_PLAYER_DATA_FILE_NAME);
        if (saveData == null)
        {
            saveData = new SaveMyUserData();
            //
            Debug.Log("因为是空的所以生成了一个新的数据"+ saveData);
        }
        loadData(saveData);
        
    }

    // 声明一个data class ，然后把各个变量进行赋值并返回class类型
    static SaveMyUserData SavingData()
    {
        var PlayerData = new SaveMyUserData();

        PlayerData._playerName = playerName;
        PlayerData._playerLevel = levelPass;
        PlayerData._playerCoin = coin;
        PlayerData._playStar = starNum;
        PlayerData._currentLevel = currentLevel;
        PlayerData._hasInitial = hasInitial;
        PlayerData._levelTotalScore = levelTotalScore;
        return PlayerData;
    }

    static void loadData(SaveMyUserData PlayerData)
    {
        Debug.Log("调用了loaddata函数");
        playerName = PlayerData._playerName;
        levelPass = PlayerData._playerLevel;
        coin = PlayerData._playerCoin;
        starNum = PlayerData._playStar;
        currentLevel = PlayerData._currentLevel;
        hasInitial =PlayerData._hasInitial;
        levelTotalScore = PlayerData._levelTotalScore;
    }

    /*static private void Awake()
    {
        r = new System.Random();
         Debug.Log("调用初始化");
         InitialUserData();
    }*/


    //因为生成的物体会从左到右，但是关卡是 S 型的，所以需要转化一下生成真实的关卡
    public static int GetRealLevel(int _level)
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
    static void InitialUserData()
    {
        LoadFromJson();
        //为什么这里loadfromjson 后就不执行了呢？
        Debug.Log("打印初始化状态"+LevelManager.hasInitial);
        if (!hasInitial)
        {
            playerName = "New User Blue"+r.Next(1,10);
            levelPass[0] = 1;
            starNum[0] = 0;
            currentLevel = 0;
            coin = 0;
            hasInitial = true;
            for (int i = 1; i < 100; i++)
            {
                levelPass[i] = 0;
                starNum[i] = 0;
            }
        }
        Debug.Log("直接结束");
        Save();
    }

    //设置所有值
    public static void SetCoin(int _coin)
    {
        coin = _coin;
        Save();
    }
    //当前通过的关卡、通过关卡的星星、下一个关卡开启
    public static void SetLevel_Star(int _level, int _star)
    {
        levelPass[_level] = 1;
        starNum[_level] = _star;
        Save();
    }
    public static void SetName(string _name)
    {
        playerName = _name;
        Save();
    }

    

}
