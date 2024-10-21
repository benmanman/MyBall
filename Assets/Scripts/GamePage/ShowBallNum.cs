using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBallNum : MonoBehaviour
{
    private Text howManyBalls;
    private ExtraBallManager extraBallManager;
    private BallController ballController;
    private BallStop ballStop;
    private Vector2 stayTransform;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    void Start()
    {
        howManyBalls = this.GetComponent<Text>();
        extraBallManager = FindObjectOfType<ExtraBallManager>();
        ballController = FindObjectOfType<BallController>();
        ballStop = FindObjectOfType<BallStop>();
    }

    // Update is called once per frame
    void Update()
    {
        
        stayTransform = ballController.ballPosition + new Vector2(20, 50);
        if (ballController.currentBallState == BallController.ballState.aim)
        {
            howManyBalls.transform.position = stayTransform;
            howManyBalls.text = "X" + (extraBallManager.numberOfBallsToFire + 1);
            howManyBalls.enabled = true;
            

        }
        else if (ballController.currentBallState != BallController.ballState.aim && extraBallManager.numberOfBallsToFire!=0)
        {
            howManyBalls.text = "X" + extraBallManager.numberOfBallsToFire;
            howManyBalls.transform.position = stayTransform;
        }
        else
        {
            howManyBalls.enabled = false;
        }
    }
}
