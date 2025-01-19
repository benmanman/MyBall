using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallStop : MonoBehaviour
{
    public Rigidbody2D ball;
    public BallController ballControl;
    private GameManager gameManager;
    private ExtraBallManager extraBallManager;
    public Vector2 LaunchPosition;//记录第一个小球碰到 end game line 的位置
    public Vector2 AnotherPosition;//测试
    public double textOffSetX;
    public int colletBallNum;//收集到多少颗球，当所有球都收集到了，那么就代表这次的发射结束了
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        extraBallManager = FindObjectOfType<ExtraBallManager>();
        LaunchPosition = Vector2.zero;
        colletBallNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //当物体进入这个collider 的时候

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            ball.velocity = Vector2.zero;
            ballControl.currentBallState = BallController.ballState.wait;
            //如果这个位置为空，则说明是第一颗球，我们就取位置
            if (LaunchPosition == Vector2.zero)
            {
                LaunchPosition = other.transform.position;
                AnotherPosition = other.transform.position;
            }
            else
            {
                other.transform.DOMove(LaunchPosition, 0.3f);
            }
        }
         if(other.gameObject.tag=="Extra Ball")
         {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if (LaunchPosition == Vector2.zero)
            {
                LaunchPosition = other.transform.position;
                AnotherPosition = other.transform.position;
            }
            else
            {
                other.transform.DOMove(LaunchPosition, 0.3f);
            }
            colletBallNum++;
        }
    }
}
