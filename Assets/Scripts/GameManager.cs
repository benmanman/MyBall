using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //这是一组坐标点，每次在这些坐标点里随机生成方块
    public Transform[] spawnPoints;
    private Text brickHealthText;

    //用来初始化的方块物体
    public GameObject squareBrick;
    public GameObject triangleBrick;
    public GameObject extraBallPowerup;
    //这是小球上的数字
    public int level;
    //一共有多少方块、三角形
    public List<GameObject> bricksInScene;

    public List<GameObject> ballsInScene;

    public Transform fatherTransform;

    // Start is called before the first frame update
    void Start()
    {
        CreateNewBrick(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateNewBrick(int healthStart, int healthEnd)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int brickToCreate = Random.Range(0, 5);
            int brickHealth = Random.Range(healthStart, healthEnd);
            if (brickToCreate == 0)
            {
                GameObject tmpobj = Instantiate(squareBrick, spawnPoints[i].position, Quaternion.identity);
                tmpobj.transform.SetParent(fatherTransform);
                if (tmpobj != null)
                {
                    Text tempText = tmpobj.GetComponentInChildren<Text>();
                    tempText.text = "" + brickHealth;
                    bricksInScene.Add(tmpobj);
                }
                
            }
            else if (brickToCreate == 1)
            {
                GameObject tmpobj = Instantiate(triangleBrick, spawnPoints[i].position, Quaternion.identity);
                tmpobj.transform.SetParent(fatherTransform);
                if (tmpobj != null) { 
                    Text tempText = tmpobj.GetComponentInChildren<Text>();
                    tempText.text = "" + brickHealth;
                    bricksInScene.Add(tmpobj);
                }
            }
            else if (brickToCreate == 2)
            {
                GameObject tmpobj = Instantiate(extraBallPowerup, spawnPoints[i].position, Quaternion.identity);
                tmpobj.transform.SetParent(fatherTransform);
                if (tmpobj != null)
                {
                    bricksInScene.Add(tmpobj);
                }
            }

        }
    }
}