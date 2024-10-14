using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmylevel : MonoBehaviour
{
    LevelManager levelManager;
    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void wingame()
    {
        levelManager.SetLevel_Star(levelManager.currentLevel, 3);
        levelManager.currentLevel++;
    }
}
