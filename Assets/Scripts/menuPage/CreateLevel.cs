using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateLevel : MonoBehaviour
{
    public GameObject normalLevel;
    public Image[] levelBg = new Image[3];//0是已解锁未选中，1 是已解锁选中，2 是未解锁
    public Transform levelFatherTransform;
    // Start is called before the first frame update
    void Start()
    {
        createMyLevel(100);//生成 100个关卡
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void createMyLevel(int levelNum)
    {
        for(int i=0; i < levelNum; i++)
        {
            Instantiate(normalLevel).transform.SetParent(levelFatherTransform);
        }
    }
    //创建礼物关卡
    void CreateGiftLevel(bool isOpen)
    {

    }
    //创建普通关卡
    void CreateNormalLevel(bool isPass, int levelNum, int starNum)
    {

    }
}
