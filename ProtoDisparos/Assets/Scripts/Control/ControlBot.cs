using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBot : MonoBehaviour
{
    private int hp;
    public GameObject yo;

    void Start()
    {
        hp = 100;
    }

    public void recibirDaño()
    {
        hp = hp - 20;
    }

    public void headShot()
    {
        hp = hp - 60;
    }

    private void Update()
    {
        if (hp <= 0)
        {
            desaparecer();
        }
    }

    private void desaparecer()
    {
        Destroy(yo);
        GameObject.Find("LVL MGR").GetComponent<ControlGanar>().cont++;
    }
}
