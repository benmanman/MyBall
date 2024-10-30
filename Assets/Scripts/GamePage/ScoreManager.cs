using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score=0;
    public Slider starSlider;

    // Start is called before the first frame update
    void Start()
    {
        starSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + score;
        
    }

    public void IncreaseScore(int i)
    {
        score+=i;
        float scoreVaule = (float)score / 100;
        starSlider.value = Mathf.Clamp(scoreVaule, 0, 1);
    }
}
