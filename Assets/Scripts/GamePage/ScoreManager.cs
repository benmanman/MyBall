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
    public Sprite[] starbgimg = new Sprite[2];
    private Image[] myStars = new Image[5];//2-4 是第 1-3 颗星星


    // Start is called before the first frame update
    void Start()
    {
        starSlider.value = 0;
        //新知识：状态不为active 的物体，用finobjectoftyp会找不到
        //successPanel = FindObjectOfType<SuccessPanel>();
        ballController = FindObjectOfType<BallController>();
        myStars = GetComponentsInChildren<Image>();
        
        myStars[2].sprite = starbgimg[0];
        myStars[3].sprite = starbgimg[0];
        myStars[4].sprite = starbgimg[0];
    }

    // Update is called once per frame
    void Update()
    {
        //若游戏成功的弹窗没有展示，则调用展示函数
        if (!successPanel.isActiveAndEnabled)
        {
            scoreText.text = "" + score;
            
             if (score >= LevelManager.levelTotalScore[LevelManager.currentLevel]&& ballController.currentBallState == BallController.ballState.aim)
            {
                successPanel.ShowGameWin(true);
                score = 0;//游戏成功后将得分置为 0
            }
        }
       
    }

    public void IncreaseScore(int i)
    {
        score+=i;
        float scoreVaule = (float)score / LevelManager.levelTotalScore[LevelManager.currentLevel];
        starSlider.value = Mathf.Clamp(scoreVaule, 0, 1);
        ShowHowManyStar();//根据用户得分显示对应的星星数，默认 10%，30%，100%
    }

    private void ShowHowManyStar()
    {
        if(score >= LevelManager.levelTotalScore[LevelManager.currentLevel]*0.1)
        {
            myStars[2].sprite = starbgimg[1];
            LevelManager.starNum[LevelManager.currentLevel] = 1;
        }
        if (score >= LevelManager.levelTotalScore[LevelManager.currentLevel] * 0.3)
        {
            myStars[3].sprite = starbgimg[1];
            LevelManager.starNum[LevelManager.currentLevel] = 1;
        }
        if (score >= LevelManager.levelTotalScore[LevelManager.currentLevel])
        {
            myStars[4].sprite = starbgimg[1];
            LevelManager.starNum[LevelManager.currentLevel] = 1;
        }
        
    }
}
