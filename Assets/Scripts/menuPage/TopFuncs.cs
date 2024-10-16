using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopFuncs : MonoBehaviour
{

    public Text diamondsNum;
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        FreshMenuData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FreshMenuData()
    {
        diamondsNum.text = levelManager.coin.ToString();
    }

    public void ClickBag()
    {
        levelManager.SetCoin(88);
        FreshMenuData();
    }
}
