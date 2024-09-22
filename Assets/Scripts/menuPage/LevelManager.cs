using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
            starNum[i] = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //因为生成的物体会从左到右，但是关卡是 S 型的，所以需要转化一下
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
