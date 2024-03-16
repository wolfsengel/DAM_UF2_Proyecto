using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AtaqueController : MonoBehaviour
{
    public Transform controladorGolpe;
    public float rangoGolpe;
    public float distanciaAtaque;
    public float distanciaVision;
    public float dañoGolpe;
    public float timeBetweenAttacks = 0.5f;
    float timer;
    private Transform player;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
     
    void Update ()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < distanciaAtaque)
        {
            Attack();
        }
        else if (distanceToPlayer < distanciaVision)
        {
            ChasePlayer();
        }
        else
        {
            //chilling
            animator.SetBool("Walking", false);
        }
    }

    void Attack()
    {
        timer += Time.deltaTime;
        if(timer >= timeBetweenAttacks)
        {
            timer = 0;
            animator.SetBool("Walking", false);
            animator.SetTrigger("Attack");
            Golpe();
        }
    }

    void ChasePlayer()
    {
        animator.SetBool("Walking", true);
        transform.position = Vector2.MoveTowards(transform.position, player.position, 2 * Time.deltaTime);
        if(transform.position.x < player.position.x)
        {
            transform.localScale = new Vector3(5, 5, 1);
        }
        else
        {
            transform.localScale = new Vector3(-5, 5, 1);
        }
    }

    void Golpe(){
        Collider2D[] objetosGolpeados = Physics2D.OverlapCircleAll(controladorGolpe.position, rangoGolpe);

        foreach (Collider2D objeto in objetosGolpeados)
        {
            if(objeto.CompareTag("Player"))
            {
                objeto.GetComponent<PlayerController>().RecibirDaño(dañoGolpe);
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, rangoGolpe);
    }
}
