using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftLevelMgr : MonoBehaviour
{
    Image[] allImages;//0是背景，1 是礼物图片
    public Sprite[] giftImage;//0是打开的礼物,1是没打开的礼物
    public Sprite[] bgImage;//0是未选中,1是选中,2是未解锁
    LevelManager levelManager;

    private void Awake()
    {
        allImages = this.gameObject.GetComponentsInChildren<Image>();
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

    public void SetGiftLevel(bool _isSelect,int _levelNum)
    {
        if (levelManager.levelPass[_levelNum-1] == 1)
        {
            //已经通过的关卡，礼物盒子打开
            allImages[1].sprite = giftImage[0];
            if (_isSelect)
            {
                allImages[0].sprite = bgImage[1];
            }
            else
            {
                allImages[0].sprite = bgImage[0];
            }
        }
        else
        {
            Debug.Log("进来了");
            allImages[1].sprite = giftImage[1];
            allImages[0].sprite = bgImage[2];
        }
    }


}
