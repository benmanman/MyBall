using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickMovementController : MonoBehaviour
{
    //方块的状态，有停止和可移动
    public enum brickState
    {
        stop,
        move
    }
    //记录当前方块状态
    public brickState currentState;
    //已经移动过的方块本次不再移动
    private bool hasMoved;
    private BallController ballController;

    // Start is called before the first frame update
    void Start()
    {
        //游戏开始的时候所有的方块状态都是stop
        currentState = brickState.stop;
        ballController = FindAnyObjectByType<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        //如果方块现在是停止状态，那么就意味着可以移动一次
        if(currentState == brickState.stop)
        {
            hasMoved = false;
        }

        //如果方块是移动的，则判断这个方块是否已经移动过。若没有移动过，则移动 1 次，然后has Moved 置为true
        //小球发射结束后，将所有方块的状态设为move
        if (currentState == brickState.move)
        {
            if (hasMoved == false)
            { 
                transform.position = new Vector2(transform.position.x, transform.position.y-122);
                currentState = brickState.stop;
                //在方块移动结束后，将球的状态设置为可瞄准
                ballController.currentBallState = BallController.ballState.aim;
                hasMoved = true;
            }
        }
    }

}
