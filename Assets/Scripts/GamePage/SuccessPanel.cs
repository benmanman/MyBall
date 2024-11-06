using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessPanel : MonoBehaviour
{
    //控制成功弹窗的星星数、礼物盒子进度、关闭按钮、开始下一关

    // Start is called before the first frame update
    void Start()
    {
        ShowGameWin(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //弹窗出现时就把等级+1

    void ClickNextLevel()
    {
        //点击下一关后， 弹窗消失，加载下一关prefab
    }

    public void ShowGameWin(bool show)
    {
        this.gameObject.SetActive(show);
    }

}
