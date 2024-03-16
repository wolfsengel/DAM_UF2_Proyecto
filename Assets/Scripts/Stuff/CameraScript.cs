using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    private float yInitial;

    void Start()
    {
        yInitial = transform.position.y;
    }
    void Update()
    {
        Vector3 position = transform.position;
        position.x = player.transform.position.x;
        transform.position = position;
        
        Vector3 position2 = transform.position;
        position2.y = player.transform.position.y;
        if (position2.y > yInitial)
        {
            transform.position = position2;
        }
        
    }
}
