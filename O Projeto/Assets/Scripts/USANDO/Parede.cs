using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parede : MonoBehaviour
{

    public bool colidindo;
    public GameObject parede;
    public GameObject paredeCover;
    private bool quebrada;

    public Animator animator;


    void Update()
    {

        if (Input.GetKeyDown("f") && colidindo)
        {
            parede.SetActive(false);
            animator.SetBool("IsFall", true);
            quebrada = true;
            paredeCover.SetActive(false);
        }

        if(Input.GetKeyDown("f") && quebrada)
        {
            parede.SetActive(false);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pai")
        {
            colidindo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colidindo = false;
    }

    void ParedeCaida ()
    {

    }

}
