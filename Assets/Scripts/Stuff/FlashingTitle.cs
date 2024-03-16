using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingTitle : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        //parpadea el titulo
        if (Time.time % 1 < 0.5)
        {
            GetComponent<Renderer>().enabled = false;
        }
        else
        {
            GetComponent<Renderer>().enabled = true;
        }
    }
}
