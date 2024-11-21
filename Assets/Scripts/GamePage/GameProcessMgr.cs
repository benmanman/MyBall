using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProcessMgr : MonoBehaviour
{
    private ScoreManager scoreManager;
    private SuccessPanel successPanel;
    private BallController ballController;

    //控制游戏成功展示成功panel，游戏失败展示失败panel

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        successPanel = FindObjectOfType<SuccessPanel>();
        ballController = FindObjectOfType<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        //调用判断函数
    }

    //用来判断游戏是否成功
    void isGameWin()
    {
        if (scoreManager.score >= 10&& ballController.currentBallState==BallController.ballState.aim)
        {
            successPanel.ShowGameWin(true);
        }

    }
}
