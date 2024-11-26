using UnityEngine;
using UnityEngine.SceneManagement;

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
        // load 下一关prefab
    }

    public void ShowGameWin(bool show)
    {
        //若游戏成功则记录本关的数据,待修改为实际数字
        if (show)
        {
            LevelManager.starNum[LevelManager.currentLevel] = 2;
            LevelManager.levelPass[LevelManager.currentLevel] = 1;
            LevelManager.currentLevel++;
            LevelManager.Save();
        }

        //游戏成功弹窗显示
        this.gameObject.SetActive(show);
    }

}
