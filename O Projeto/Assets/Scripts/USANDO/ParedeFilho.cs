using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeFilho : MonoBehaviour
{
    public bool colidindo;
    public GameObject parede;
    public GameObject paredePai;

    public Animator animator;

    private void Update()
    {
        if (Input.GetKeyDown("f") && colidindo)
        {
            parede.SetActive(true);
            animator.SetBool("IsVolta", true);
            paredePai.SetActive(false);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Filho") 
        {
            colidindo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colidindo = false;
    }
}
