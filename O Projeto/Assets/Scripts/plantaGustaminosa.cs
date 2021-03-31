using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class plantaGustaminosa : MonoBehaviour
{
    public static bool quebrarMaquina;

    public Animator animator;

    private bool colidiu;
    private int estado;
    private bool ativo;
    private bool estadoQuebra;
    

    private void Awake()
    {
        estado = 1;
    }

    private void Update()
    {
        if(ativo && Input.GetKeyDown("q"))
        {
            if (estado == 1) estado = 2;
            if (estado == 2) estado = 1;
            UnityEngine.Debug.Log("aaquiii");
        }

        if(estado == 1)
        {
            animator.SetBool("diminuir", false);
            animator.SetBool("crescer", true);
            estadoQuebra = false;
            UnityEngine.Debug.Log("1");
        }
        else if(estado == 2)
        {
            animator.SetBool("diminuir", true);
            animator.SetBool("crescer", false);
            estadoQuebra = true;
            UnityEngine.Debug.Log("2");
        }

        if (estadoQuebra && colidiu)
        {
            quebrarMaquina = true;
        }
        else quebrarMaquina = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Filho")
        {
            ativo = true;
        }
        if(collision.gameObject.name == "Esmaga")
        {
            colidiu = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Filho")
        {
            ativo = false;
        }
        if (collision.gameObject.name == "Esmaga")
        {
            colidiu = false;
        }
    }
}
