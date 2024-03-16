using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    private BoxCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.setVida(100f);
            destroyMyself();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void destroyMyself()
    {
        Destroy(gameObject);
    }
}
