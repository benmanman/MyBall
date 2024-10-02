using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NormalLevelMgr : MonoBehaviour
{
    public Sprite[] bg;//0 是已解锁未选中，1 是已解锁选中，2 是未解锁,3是亮的星星，4 是不亮的星星
    private Image[] allImage;//0 是背景，1 是箭头，2-4 是星星，5 是锁
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

    public void SetNormalLevel(int levelNum)
    {
        //情况 1：已解锁未选中，情况 2：已解锁已选中，情况 3：未解锁
        //先设置背景图片，关卡数字
        bool isSelect;
        if(levelNum == levelManager.currentLevel)
        {
            isSelect = true;
        }
        else
        {
            isSelect = false;
        }
        SetbgImage(isSelect, levelNum);

        //设置关卡数字
        levelNumText.text = levelNum.ToString();//关卡等于传进来的数字
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
                allImage[5].enabled = false;//若是已经解锁的，就隐藏锁
                SetStarsUnable(true, levelManager.starNum[levelNum]);//展示星星
            }
            else
            {
                allImage[0].sprite = bg[0];//未选中图
                allImage[5].enabled = false;//若是已经解锁的，就隐藏锁
                SetStarsUnable(true, levelManager.starNum[levelNum]);//展示星星
            }
        }
        else
        {
            allImage[0].sprite = bg[2];//未解锁，只有一种情况
            allImage[5].enabled = true;//若是未解锁，则展示锁
            SetStarsUnable(false, levelManager.starNum[levelNum]);// 不显示星星

            levelNumText.GetComponentInChildren<Outline>().enabled = false;
        }
    }

    //点击关卡则触发该函数
    public void ClickNormalLevel()
    {
        SceneManager.LoadScene("GamePage");
    }

    private void SetStarsUnable(bool _show, int _starNum)
    {
        //如果为不展示，那就直接全部隐藏就行
        //如果是展示，再判断需要给几颗星星点亮
        if (_show)
        {
            SetStarImage(_starNum);
            allImage[2].enabled = true;
            allImage[3].enabled = true;
            allImage[4].enabled = true;
        }
        else
        {
            allImage[2].enabled = false;
            allImage[3].enabled = false;
            allImage[4].enabled = false;
        }
    }

    private void SetStarImage(int _starNum)
    {
        //如果是 0 颗，如果是 1 颗...
        switch (_starNum)
        {
           case 0:
                break;
            case 1:
                allImage[2].sprite = bg[3];
                break;
            case 2:
                allImage[2].sprite = bg[3];
                allImage[3].sprite = bg[3];
                break;
            case 3:
                allImage[2].sprite = bg[3];
                allImage[3].sprite = bg[3];
                allImage[4].sprite = bg[3];
                break;
        }

    }

}
