using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alavancaIma : MonoBehaviour
{
    private bool detecta;
    public controleMaquinaIma maquina;
    public Animator animator;
    public GameObject alavanca;

    private void Update()
    {
        if (detecta && Input.GetKeyDown("e"))
        {
            maquina.Ativou();
            animator.SetTrigger("Ativa");
            alavanca.GetComponent<SpriteRenderer>().enabled = false;
            alavanca.GetComponent<alavanca>().enabled = false;
            alavanca.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }   
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Filho") 
        {
            detecta = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detecta = false;
    }


}
