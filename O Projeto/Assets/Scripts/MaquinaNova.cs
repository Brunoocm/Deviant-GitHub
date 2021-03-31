using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MaquinaNova : MonoBehaviour
{
    public Animator anim;
    public GameObject planta;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PararMaquina"))
        {
            anim.SetTrigger("Parada");
            planta.GetComponent<BoxCollider2D>().enabled = false;
            planta.GetComponent<BoxPush>().enabled = false;
            planta.GetComponent<FixedJoint2D>().enabled = false;
            planta.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f); 
        }

        if (other.gameObject.CompareTag("Filho"))
        {
            anim.SetTrigger("Morto");

        }
    }

}
