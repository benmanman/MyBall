using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalLevelMgr : MonoBehaviour
{
    public Sprite[] bg;//0 是已解锁未选中，1 是已解锁选中，2 是未解锁
    private Image[] allImage;
    private Text levelNumText;
    public GameObject totalbgWithArrow;
    private LevelManager levelManager;

    private void Awake()
    {
        //0是背景图，1 是箭头，2 是，3，4，5 是星星
        allImage= this.gameObject.GetComponentsInChildren<Image>();
        levelNumText = this.gameObject.GetComponentInChildren<Text>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNormalLevel(bool isSelect, int levelNum)
    {
        //情况 1：已解锁未选中，情况 2：已解锁已选中，情况 3：未解锁
        //先设置背景图片，关卡数字
        SetbgImage(isSelect, levelNum);

        //设置关卡数字
        levelNumText.text = levelNum.ToString();//关卡等于传进来的数字
        //SetLevelNum(levelNum);
        //然后判断箭头方向
        bool rightArrow = GetDirection(levelNum);
        if (rightArrow)
        {
            totalbgWithArrow.transform.localScale = new Vector3(-1,1,1);//箭头超右 
        }
        else
        {
            totalbgWithArrow.transform.localScale = new Vector3(1, 1, 1);//箭头超左 
        }
    }

    private bool GetDirection(int _level)
    {
        if (_level % 10 < 5)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    private void SetbgImage(bool isSelect, int levelNum)
    {
        if (levelManager.levelPass[levelNum] == 1)
        {
            if (isSelect)//如果已选中
            {
                allImage[0].sprite = bg[1];//选中图
            }
            else
            {
                allImage[0].sprite = bg[0];//未选中图
            }
        }
        else
        {
            allImage[0].sprite = bg[2];//未解锁，只有一种情况
        }
    }
    private void SetLevelNum(int _level)
    {
        if (_level % 10 < 5)
        {
            levelNumText.text = _level.ToString();//关卡等于传进来的数字
        }
        else
        {
            //int n = (int)Math.Ceiling(_level/10.00);
            //int reelLevel = n * 10 - (_level % 5);
            //levelNumText.text = reelLevel.ToString();//关卡等于传进来的数字

        }
        
    }

}
