using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopFuncs : MonoBehaviour
{

    public Text diamondsNum;
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        FreshMenuData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //从别的页面进入menu 页面时，刷新一下页面上的数据
    private void FreshMenuData()
    {
        diamondsNum.text = levelManager.coin.ToString();

    }

    public void ClickBag()
    {
        levelManager.SetCoin(88);
        FreshMenuData();
    }

    public void ClickDelete()
    {
        levelManager.DeleteData();
    }


    //测试阶段，每点击一次，级别升 1
    public void ClickSetting()
    {
        levelManager.levelPass[levelManager.currentLevel] = 1;
        levelManager.starNum[levelManager.currentLevel] = 3;
        levelManager.currentLevel++;
        levelManager.Save();
        FreshMenuData();
    }
}
