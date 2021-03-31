 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaQueEsmaga : MonoBehaviour
{

    public Collider2D collider;
    public Animator animator;

    private bool esmagando;

    private void Start()
    {
    }

    private void Update()
    {

        if (!plantaGustaminosa.quebrarMaquina)
        {
            Funcionando();
        }
        else if(plantaGustaminosa.quebrarMaquina)
        {
            Quebrada();
        }     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(esmagando)
        {
            if(collision.gameObject.name == "Filho")
            {
                //MORRE
            }
        }
    }

    public void Funcionando ()
    {
        animator.SetBool("Funcionando", true);
    }

    public void Quebrada ()
    {
        animator.SetTrigger("Quebrando");
        animator.SetBool("Funcinando", false);
        collider.enabled = false;
    }


    public void AtivaCollider ()
    {
        esmagando = true;
    }

    public void DesativaCollider ()
    {
        esmagando = false;
    }

}
