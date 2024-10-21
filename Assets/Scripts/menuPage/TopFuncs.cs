using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopFuncs : MonoBehaviour
{

    public Text diamondsNum;
    //private LevelManager levelManager;
    public System.Random r;
    // Start is called before the first frame update
    void Start()
    {
       // levelManager = FindObjectOfType<LevelManager>();
        r = new System.Random();
        FreshMenuData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //从别的页面进入menu 页面时，刷新一下页面上的数据
    private void FreshMenuData()
    {
        diamondsNum.text = LevelManager.coin.ToString();
    }

    public void ClickBag()
    {
        LevelManager.SetCoin(88);
        FreshMenuData();
    }

    public void ClickDelete()
    {
        LevelManager.DeleteData();
        FreshMenuData();
    }

    //测试阶段，每点击一次，级别升 1
    public void ClickSetting()
    {
        LevelManager.levelPass[LevelManager.currentLevel] = 1;
        LevelManager.starNum[LevelManager.currentLevel] = r.Next(1,4);
        Debug.Log(LevelManager.starNum[LevelManager.currentLevel]);
        LevelManager.currentLevel++;
        LevelManager.Save();
        FreshMenuData();
    }
}
