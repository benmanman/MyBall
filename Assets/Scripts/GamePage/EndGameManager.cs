using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    private BallController ballController;
    public GameObject endGamePanel;
   

    // Start is called before the first frame update
    void Start()
    {
        ballController = FindObjectOfType<BallController>();
        endGamePanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Square Brick"|| other.gameObject.tag == "Triangle Brick" || other.gameObject.tag=="Ball Brick")
        {
            ballController.currentBallState = BallController.ballState.endGame;
            endGamePanel.SetActive(true);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("GamePage");
    }

    public void Quit()
    {
        SceneManager.LoadScene("MenuPage");
    }

}
