using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mussrum : MonoBehaviour
{
    public float vida;
    private Animator animator;
    public float velocidad = 2f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public float getVida()
    {
        return vida;
    }
    
    public void RecibirDaño(float daño)
    {
        animator.SetTrigger("Hit");
        vida -= daño;
        if(vida <= 0)
        {
            Muerte();
        }
    }
    private void Muerte()
    {
        animator.SetTrigger("Muerte");
        Destroy(gameObject, 1f);
    }

    void pantallaVictoria()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Victoria");
    }
    
}
