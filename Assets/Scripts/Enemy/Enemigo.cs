using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
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
/*
    void FixedUpdate()
    {
        //walking(shouldMove);
    }

    void walking(bool shouldI){
        if(shouldI){
            
        contador += Time.fixedDeltaTime;
        if (contador >= 2f)
        {
            moverIzquierda = !moverIzquierda;
            contador = 0;
        }

        if (moverIzquierda)
        {
            transform.Translate(-Vector2.right * velocidad * Time.fixedDeltaTime);
            transform.localScale = new Vector3(-5, 5, 1);
        }
        else
        {
            transform.Translate(Vector2.right * velocidad * Time.fixedDeltaTime);
            transform.localScale = new Vector3(5, 5, 1);
        }

        animator.SetBool("Walking", true);
        }
    }
*/
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
    
}
