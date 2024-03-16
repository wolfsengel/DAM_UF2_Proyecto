using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CapsuleCollider2D coll;
    private Animator anim;
    private Rigidbody2D rb;
    private float horizontal;
    private bool enSuelo;
    public float fuerzaSalto = 100f;
    public float fuerzaDash = 100f;
    public float speed = 10f;

    public float vida = 100f;
    private bool rolling;

    public float getVida()
    {
        return vida;
    }

    public void setVida(float vida)
    {
        this.vida = vida;
    }


    void Start()
    {
        rolling = false;
        enSuelo = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-5.0f, 5.0f, 1.0f);
        }
        else if (horizontal > 0.0f)
        {
            transform.localScale = new Vector3(5.0f, 5.0f, 1.0f);
        }

        if (Input.GetKeyDown(KeyCode.E) && enSuelo && horizontal != 0.0f)
        {
            if (horizontal < 0.0f && !rolling)
            {
                rolling = true;
                anim.SetTrigger("Roll");
                rb.AddForce(Vector2.left * fuerzaDash);
                transform.localScale = new Vector3(-5.0f, 5.0f, 1.0f);
            }
            else if (horizontal > 0.0f && !rolling)
            {rolling = true;
                anim.SetTrigger("Roll");
                rb.AddForce(Vector2.right * fuerzaDash);
                transform.localScale = new Vector3(5.0f, 5.0f, 1.0f);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Attack1");
        }
        else
        {
            anim.ResetTrigger("Attack1");
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            anim.SetTrigger("Attack2");
        }
        else
        {
            anim.ResetTrigger("Attack2");
        }

        anim.SetBool("Running", horizontal != 0.0f);

        anim.SetBool("Up", rb.velocity.y > 0.0f && !enSuelo);
        anim.SetBool("Down", rb.velocity.y < 0.0f && !enSuelo);

        enSuelo = IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.W) && enSuelo)
        {
            Jump();
        }

    }

    void Jump()
    {
        enSuelo = false;
        rb.AddForce(Vector2.up * fuerzaSalto);
    }


    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    bool IsGrounded()
    {
        float raycastLength = coll.bounds.extents.y + 0.2f;

        RaycastHit2D hit = Physics2D.Raycast(coll.bounds.center, Vector2.down, raycastLength, Physics2D.AllLayers);
        Debug.DrawRay(coll.bounds.center, Vector2.down * raycastLength, Color.red);
        return hit.collider != null;
    }

    public void RecibirDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("DeadScene");
        }
    }

    private void falseRoll()
    {
        rolling = false;
    }
}
