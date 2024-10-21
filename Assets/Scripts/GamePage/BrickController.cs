using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickController : MonoBehaviour
{
    //这是让物体随机取色的东西
    public Gradient gradient;

    private Image myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Image>();
        myRenderer.color = gradient.Evaluate(Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
