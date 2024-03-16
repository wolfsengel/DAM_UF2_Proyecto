using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject player;
    void Start()
    {
        
    }

    void Update()
    {
        //si el jugador baja de la pantalla, se reinicia la escena
        if (player.transform.position.y < -5)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("DeadScene");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}
