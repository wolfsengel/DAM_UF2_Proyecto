using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossController : MonoBehaviour
{
    public GameObject finalBoss;
    void Start()
    {
        
    }

    void Update()
    {
        if(finalBoss == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
        }
    }
}
