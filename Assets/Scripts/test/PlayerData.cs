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

    void LoadByPlayerPrefabs()
    {
        var json = SaveSystem.LoadFromJson(PLAYER_DATA_KEY);
        var saveData = JsonUtility.FromJson<SaveData>(json);
        playerName = saveData.playerName;
        level = saveData.playerLevel;
        coin = saveData.playerCoin;

        //data2Data(saveData.myint,testlevel);
    }

    [UnityEditor.MenuItem("Developer/Delete All Data")]
    public static void DeletePlayerDataPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    void SaveByJson()
    {
        SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME, SavingData());
    }

    void LoadFromJson()
    {
        var saveData = SaveSystem.LoadFromJson<SaveData>(PLAYER_DATA_FILE_NAME);
        loadData(saveData);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   /* private void data2Data(int[] orig, int[] final)
    {
        for(int i=0; i<orig.Length; i++)
        {
            final[i] = orig[i];
        }
    }*/

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
