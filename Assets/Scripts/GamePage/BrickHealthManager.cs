using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickHealthManager : MonoBehaviour
{
    //控制方块的生命值
    public int brickHealth;
    private Text brickHealthText;
    private GameManager gameManager;
    private ScoreManager scoreManager;
    public GameObject birckDestroyPartical;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        brickHealthText = GetComponentInChildren<Text>();
        brickHealth = int.Parse(brickHealthText.text);
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        brickHealthText.text = "" + brickHealth;
        if (brickHealth <= 0)
        {
            scoreManager.IncreaseScore(1);
            gameManager.bricksInScene.Remove(this.gameObject);
            Destroy(this.gameObject);


        }
    }

    void TakeDamage(int damageToTake)
    {
        brickHealth -= damageToTake;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "Extra Ball")
        {
            TakeDamage(1);
        }
    }

}
