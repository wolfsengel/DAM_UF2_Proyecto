using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update()
    {
        //si pulsa intro o espacio cambia a la escena del juego
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
        }
    }
}
