using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int[] levelPass = new int[100];//先假设是 100 关，0 是未完成，1 是已完成
    public int[] starNum = new int[100];//每一关的星星个数

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i < 27; i++)
        {
            levelPass[i] = 1;//造个数据，前 27 关已过
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
