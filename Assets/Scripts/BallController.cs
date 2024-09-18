using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //球的 5 个状态
    public enum ballState
    {
        aim,//可发射
        fire,//已发射
        wait,//等待发射
        endShot,//发射结束
        endGame//结束游戏
    }

    public ballState currentBallState;
    public Rigidbody2D ball;
    private Vector2 mouseStartPosition;
    private Vector2 mouseEndPosition;
    public Vector2 tempVelocity;
    private float ballVelocityX;
    private float ballVelocityY;
    public float constantSpeed;

    public GameObject arrow;
    private GameManager gameManager;
    private ExtraBallManager extraBallManager;
    private BallStop ballStop;
    public Vector3 ballLaunchPosition;
    public bool isPress = false;
    public Vector2 ballPosition;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        ballStop = FindObjectOfType<BallStop>();
        extraBallManager = FindObjectOfType<ExtraBallManager>();
        currentBallState = ballState.aim;//开始游戏，所有的球默认是可发射状态
        //gameManager.ballsInScene.Add(this.gameObject);//这步是把主球也加到这个池子里
        ballPosition = this.gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // 每一帧都按照球的当前状态
         switch (currentBallState)
        {
            case ballState.aim:
                ballStop.colletBallNum = 0;//结束一次射击，将收集小球个数重置
                extraBallManager.numberOfBallsToFire = gameManager.ballsInScene.Count;//结束一次射击，将待发射的小球个数重置
                
                if (Input.GetMouseButtonDown(0))//点击鼠标左键
                {
                    MouseClicked();
                    return;
                }
                if (isPress)//鼠标左键按住拖拉
                {
                    MouseDragged();
                }
                if (Input.GetMouseButtonUp(0))//鼠标左键抬起
                {
                    ReleaseMouse();
                    //鼠标抬起，开始发射小球，小球的降落位置先置空
                    ballStop.LaunchPosition = Vector2.zero;
                    extraBallManager.ballWaitTimeSeconds = extraBallManager.ballWaitTime;
                    
                }
                break;
            case ballState.wait:
                //currentBallState = ballState.endShot;
                if (ballStop.colletBallNum==gameManager.ballsInScene.Count)
                {
                    currentBallState = ballState.endShot;
                }
                break;
            case ballState.fire:
      
                break;
            case ballState.endShot:
                //要是球的状态变成了endshot，那就给 gameManager 里面所有的方块状态设为 move
                for(int i=0; i < gameManager.bricksInScene.Count; i++)
                {
                    gameManager.bricksInScene[i].GetComponent<BrickMovementController>().currentState = BrickMovementController.brickState.move;
                }
                gameManager.CreateNewBrick(1,5);
                ballPosition = this.gameObject.transform.position;
                break;
            case ballState.endGame:

                break;
            default:
                break;

        }

    }

    //点击的时候将坐标拿出来
    public void MouseClicked()
    {
        mouseStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isPress = true;
    }

    //识别到鼠标拖动了，就出现箭头
    public void MouseDragged() 
    {
        //Move the Arrow
        arrow.SetActive(true);
        Vector2 tempMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float diffX = mouseStartPosition.x - tempMousePosition.x;
        float diffY = mouseStartPosition.y - tempMousePosition.y;
        if (diffY <= 0)
        {
            arrow.SetActive(false);
            diffY = 0.01f;
        }
        // mathf.rad2deg 是将弧度转成角度，反之则是角度转成弧度
        float theta = Mathf.Rad2Deg * Mathf.Atan(diffX / diffY);//得到角度
        arrow.transform.rotation = Quaternion.Euler(0f, 0f, -theta);
    }

    public void ReleaseMouse()
    {
        isPress = false;
        arrow.SetActive(false);
        mouseEndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ballVelocityX = (mouseStartPosition.x - mouseEndPosition.x);
        ballVelocityY = (mouseStartPosition.y - mouseEndPosition.y);
        //新的二维向量由 X 和 Y 组成，normalized 是不管这个向量由多长都取 1 并保留方向
        tempVelocity = new Vector2(ballVelocityX, ballVelocityY).normalized;
        ball.velocity = constantSpeed * tempVelocity;
        if(ball.velocity == Vector2.zero)
        {
            return;
        }
        //每次释放鼠标后，小球的状态就改成已发射
        ballLaunchPosition = transform.position;
        currentBallState = ballState.fire;    
    }

}
