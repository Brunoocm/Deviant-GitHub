using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controleCerca : MonoBehaviour
{
    public Collider2D cercaFechada;
    public float duraçãoInteração;
    public Animator animator;

    private bool ativo;
    private bool poderAtivo;
    private float durPoder;

    private void Start()
    {
        cercaFechada.enabled = false;
    }

    public void Update()
    {
        
        if(ativo)
        {
            if (Input.GetKeyDown("r")) poderAtivo = true;

            if (Input.GetKeyUp("r")) poderAtivo = false;
        }

        if (poderAtivo) durPoder += Time.deltaTime;
        else durPoder = 0;


        if(durPoder >= duraçãoInteração)
        {
            if (Input.GetKeyDown("a") || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (animator == null) return;
                cercaFechada.enabled = false;
                animator.SetBool("Aberta", true);
            }
                
            if (Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (animator == null) return;
                animator.SetBool("Aberta", false);
                cercaFechada.enabled = true;
                animator.SetTrigger("Fecha");
                animator.SetBool("Fechada", true);
            }
               
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Filho")
        {
            ativo = true;
        }
        else ativo = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Filho") ativo = false;
    }

}
