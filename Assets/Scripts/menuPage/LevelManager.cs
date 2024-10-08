using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public int[] levelPass = new int[100];//先假设是 100 关，0 是未解锁，1 是已解锁
    public int[] starNum = new int[100];//每一关的星星个数,是0，1，2，3
    public int currentLevel;//记录
    private System.Random r;

    // Start is called before the first frame update
    void Start()
    {
        /*
        r = new System.Random();
        for (int i=0; i < 13; i++)
        {
            levelPass[i] = 1;//造个数据，前 27 关已过
            starNum[i] = r.Next(0, 3);
        }
        currentLevel = 5;*/

        //start的时候需要读取保存在本地的关卡数据
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //因为生成的物体会从左到右，但是关卡是 S 型的，所以需要转化一下生成真是的关卡
    public int GetRealLevel(int _level)
    {
        if (_level % 10 < 5)
        {
            return _level+1;
        }
        else
        {
            int n = (int)Math.Ceiling(_level / 10.00);
            int realLevel = n * 10 - (_level % 5);
            return realLevel;
        }
    }
}
