using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePageTopFunc : MonoBehaviour
{

    public Text diamondsNum;
    //private LevelManager levelManager;
    //public System.Random r;
    // Start is called before the first frame update
    void Start()
    {  
        diamondsNum.text = LevelManager.coin.ToString();
        LevelManager.Load();//回头可以删掉
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FreshPageData()
    {
        diamondsNum.text = LevelManager.coin.ToString();
    }

    public void ClickShop()
    {
        // 加号和商店点击后都是这个函数
        //点击商店后进入商店页面，可能做个panel 或者单独的页面？到时候请教诶姆看什么形式更好

        LevelManager.coin += 1;
        FreshPageData();
        LevelManager.Save();
    }

    public void ClickStop()
    {
        //点击后出发暂停的panel ，这个应该是个panel。展示暂停页面
        //测试，假装是游戏成功升级
        LevelManager.levelPass[LevelManager.currentLevel] = 1;
        LevelManager.starNum[LevelManager.currentLevel] = 3;
        LevelManager.currentLevel++;
        LevelManager.Save();
    }
}
