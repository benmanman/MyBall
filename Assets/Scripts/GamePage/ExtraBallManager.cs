using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraBallManager : MonoBehaviour
{

    private BallController ballController;
    private GameManager gameManager;
    private BallStop ballStop;
    public float ballWaitTime;
    public float ballWaitTimeSeconds;
    public int numberOfExtraBalls;
    public int numberOfBallsToFire;

    public int needInit;//当需要生成 1 个球时，该数+1
    

    //自己加的
    public GameObject extraBall;

    // Start is called before the first frame update
    void Start()
    {
        ballController = FindObjectOfType<BallController>();
        gameManager = FindObjectOfType<GameManager>();
        ballStop = FindObjectOfType<BallStop>();
        ballWaitTimeSeconds = ballWaitTime;
        numberOfExtraBalls = 0;
        numberOfBallsToFire = 0;
        needInit = 0;

    }

    // Update is called once per frame
    void Update()
    {
        ballWaitTimeSeconds -= Time.deltaTime;//等待的时间减一个数，等于 0 就可以生成一个小球

        if (needInit > 0)
        {
            if (ballWaitTimeSeconds < 0 && ballController.currentBallState == BallController.ballState.aim)//当等待时间小于 0 并且需要初始化的小球大于 0 个
            {
                CreateExtraBall();
            }
        }
        if (ballController.currentBallState == BallController.ballState.fire || ballController.currentBallState == BallController.ballState.wait)
        {
            if (numberOfBallsToFire > 0)
            {
                if (ballWaitTimeSeconds <= 0)
                {
                    gameManager.ballsInScene[numberOfBallsToFire - 1].GetComponent<Rigidbody2D>().velocity = ballController.tempVelocity * ballController.constantSpeed;
                    numberOfBallsToFire--;
                    ballWaitTimeSeconds = ballWaitTime;
                }
            }
        }
    }

    private void CreateExtraBall()
    {
        for(int i=0; i < needInit; i++)
        {
            GameObject ball = Instantiate(extraBall);
            ball.transform.SetParent(gameManager.fatherTransform);
            if (ball != null)
            {
                ball.transform.position = ballStop.LaunchPosition;
                ball.SetActive(true);
                gameManager.ballsInScene.Add(ball);
                i++;
            }
        }
        needInit = 0;//生成所有小球后，将待初始化小球个数设为 0 个

    }

}
