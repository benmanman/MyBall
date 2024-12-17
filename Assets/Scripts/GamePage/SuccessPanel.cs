using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SuccessPanel : MonoBehaviour
{
    //控制成功弹窗的星星数、礼物盒子进度、关闭按钮、开始下一关

    // Start is called before the first frame update

    public Sprite[] stars = new Sprite[2];//装星星图片
    public Image[] starBg = new Image[5];//获得显示星星的区域，4-6 是第1-3 颗星星

    void Start()
    {
        ShowGameWin(false);
        starBg = GetComponentsInChildren<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //弹窗出现时就把等级+1

    public void ClickNextLevel()
    {
        //点击下一关后， 弹窗消失，加载下一关prefab
        //先让弹窗消失
        ShowGameWin(false);
        SceneManager.LoadScene("GamePage");
        //本关卡信息
        // load 下一关prefab
    }

    //点击关闭按钮，回到menu页面
    public void ClickClose()
    {
        //点击下一关后， 弹窗消失，加载下一关prefab
        //先让弹窗消失
        //ShowGameWin(false);
        SceneManager.LoadScene("MenuPage");
        //本关卡信息
        //load 下一关prefab
    }

    public void ShowGameWin(bool show)
    {
        //若游戏成功则记录本关的数据,待修改为实际数字
        //若游戏的弹窗没有显示，则关卡不加一，数据也不更新
        if (show)
        {
            //将当前成功的关卡记上星星和过关
            ShowStars();
            LevelManager.levelPass[LevelManager.currentLevel+1] = 1;
            
            LevelManager.currentLevel++;
            LevelManager.Save();
        }

        //游戏成功弹窗显示
        this.gameObject.SetActive(show);
    }

    private void ShowStars()
    {
        int n = LevelManager.starNum[LevelManager.currentLevel];
        Debug.Log(n);
        while(n>0)
        {
            starBg[3 + n].sprite = stars[1];
            n--;
        }
    }

}
