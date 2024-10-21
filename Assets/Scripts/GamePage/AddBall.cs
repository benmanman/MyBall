using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBall : MonoBehaviour
{
    // 这个是游戏场景中的小球被ball 碰撞后，将游戏内可发射的小球数量+1，并且被碰撞的小球直接不可见
    private ExtraBallManager extraBallManager;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        extraBallManager = FindObjectOfType<ExtraBallManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "Extra Ball")
        {
            //add an extra ball
            extraBallManager.numberOfExtraBalls++;
            extraBallManager.needInit++;
            //this.gameObject.SetActive(false);
            gameManager.bricksInScene.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
