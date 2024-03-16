using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombateScript : MonoBehaviour
{
    public Transform controladorGolpe;
    public float rangoGolpe;
    public float dañoGolpe;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Golpe();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Golpe();
        }
    }

    private void Golpe(){
        Collider2D[] objetosGolpeados = Physics2D.OverlapCircleAll(controladorGolpe.position, rangoGolpe);

        foreach (Collider2D objeto in objetosGolpeados)
        {
            if(objeto.CompareTag("Enemigo"))
            {
                try{objeto.GetComponent<Enemigo>().RecibirDaño(dañoGolpe);}
                catch{objeto.GetComponent<Mussrum>().RecibirDaño(dañoGolpe);}
                
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, rangoGolpe);
    }
}
