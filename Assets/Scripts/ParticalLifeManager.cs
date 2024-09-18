using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalLifeManager : MonoBehaviour
{
    public float lifeTime;
    private float lifeTimeSecond;
    // Start is called before the first frame update
    void Start()
    {
        lifeTimeSecond = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimeSecond -= Time.deltaTime;
        if (lifeTimeSecond <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
