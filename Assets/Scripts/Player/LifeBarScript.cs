using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarScript : MonoBehaviour
{
    public PlayerController LivingBeing;
    public Enemigo LivingBeing2;
    public Mussrum LivingBeing3;
    private float vida;

    void Update()
    {
        if (LivingBeing != null) vida = LivingBeing.getVida();
        else if (LivingBeing2 != null) vida = LivingBeing2.getVida();
        else if (LivingBeing3 != null) vida = LivingBeing3.getVida();
        else vida = 0;
        if (vida <= 0) Destroy(gameObject);

        if(LivingBeing3!=null)transform.localScale = new Vector3(vida / 400, 0.02f, 0.02f);
        else transform.localScale = new Vector3(vida / 200, 0.02f, 0.02f);
    }
}
