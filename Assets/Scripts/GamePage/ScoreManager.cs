using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score=0;
    public Slider starSlider;
    public SuccessPanel successPanel;
    private BallController ballController;


    // Start is called before the first frame update
    void Start()
    {
        starSlider.value = 0;
        //新知识：状态不为active 的物体，用finobjectoftyp会找不到
        //successPanel = FindObjectOfType<SuccessPanel>();
        ballController = FindObjectOfType<BallController>();

    }

    // Update is called once per frame
    void Update()
    {
        //若游戏成功的弹窗没有展示，则调用展示函数
        if (!successPanel.isActiveAndEnabled)
        {
            scoreText.text = "" + score;
            if (score >= 10 && ballController.currentBallState == BallController.ballState.aim)
            {
                successPanel.ShowGameWin(true);
                score = 0;//游戏成功后将得分置为 0
            }
        }
       
    }

    public void IncreaseScore(int i)
    {
        score+=i;
        float scoreVaule = (float)score / 100;
        starSlider.value = Mathf.Clamp(scoreVaule, 0, 1);
    }
}
