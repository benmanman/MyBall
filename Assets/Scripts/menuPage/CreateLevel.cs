using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateLevel : MonoBehaviour
{
    public GameObject normalLevel;//普通关卡的prefab
    public GameObject giftLevel;//礼物关卡的prefab 
    public Transform levelFatherTransform;

    LevelManager levelManager;
    
    // Start is called before the first frame update
    void Start()
    {
        //生成 100 个关卡
        levelManager = FindObjectOfType<LevelManager>();
        createMyLevel(100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void createMyLevel(int _howManyLevel)
    {
        //生成 100个关卡
        
        for (int i = 0; i < _howManyLevel; i++)
        {
            int realLevel = levelManager.GetRealLevel(i);
            //如果是 5 的整数倍，那就是礼物盒子
            if ((realLevel) % 5 == 0)
            {
                CreateGiftLevel(realLevel);
            }else
            {
                CreateNormalLevel(realLevel, 1);
            }
        }
    }

    //创建礼物关卡
    void CreateGiftLevel(int levelNum)
    {
        GameObject tempObj= Instantiate(giftLevel);
        tempObj.transform.SetParent(levelFatherTransform);
        tempObj.GetComponentInChildren<GiftLevelMgr>().SetGiftLevel(false, levelNum);

    }
    //创建普通关卡
    void CreateNormalLevel(int levelNum, int starNum)
    {
        GameObject tempObj = Instantiate(normalLevel);
        tempObj.transform.SetParent(levelFatherTransform);
        //instantiate 出来的物体无法直接访问脚本上的方法，需要先获取脚本
        tempObj.GetComponentInChildren<NormalLevelMgr>().SetNormalLevel(false, levelNum);
    }
}
