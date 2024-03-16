using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    
    void Start()
    {
        
    }
    
    void Update()
    {
        //si pulsa intro o espacio cambia a la escena del juego
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SabelasParadise");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
