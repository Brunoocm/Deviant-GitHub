using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controleArvoreOld : MonoBehaviour
{
    public GameObject tronco;
    public Transform alturaUm;
    public Transform alturaDois;
    public Transform alturaTres;
    public float duracaoInteracao;
    public GameObject travaCano;
   // public Animator animator;
    [Range(0, 10)]
    public float velTronco;

    private float velocidade;
    private bool ativo;
    private bool avancaAtivo;
    private bool recuaAtivo;  
    private float timerAvanca;
    private float timerRecua;
    private int estado = 2;
    private Transform alturaAtual;


    private void Update()
    {
        velocidade = velTronco * Time.deltaTime;

        

        if(ativo)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow)) avancaAtivo = true;
            else if (Input.GetKeyUp(KeyCode.RightArrow)) avancaAtivo = false;

            if (Input.GetKeyDown(KeyCode.LeftArrow)) recuaAtivo = true;
            else if (Input.GetKeyUp(KeyCode.LeftArrow)) recuaAtivo = false;
        }

        if (avancaAtivo) timerAvanca += Time.deltaTime;
        else timerAvanca = 0;

        if (recuaAtivo) timerRecua += Time.deltaTime;
        else timerRecua = 0;    

        if(timerAvanca >= duracaoInteracao)
        {
            timerAvanca = 0;

            if (estado == 1) estado = 2;
            else estado = 3;
        }
        if(timerRecua >= duracaoInteracao)
        {
            timerRecua = 0;

            if (estado == 3) estado = 2;
            else estado = 1;
        }

        if (estado == 1) estadoUm();
        if (estado == 2) estadoDois();
        if (estado == 3) estadoTres();


        //if (animator == null) return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Filho")  ativo = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Filho") ativo = false;
    }

    public void estadoUm ()
    {
        //animator.SetTrigger("2-1");
        //animator.SetBool("Estado1", true);
        tronco.transform.position = Vector2.MoveTowards(tronco.transform.position, alturaUm.transform.position, velocidade);
        travaCano.SetActive(false);
    }

    public void estadoDois()
    {
        //if (recuaAtivo) animator.SetTrigger("3-2");
        //else if (avancaAtivo) animator.SetTrigger("1-2");

        //animator.SetBool("Estado1", true);
        tronco.transform.position = Vector2.MoveTowards(tronco.transform.position, alturaDois.transform.position, velocidade);
    }

    public void estadoTres()
    {
        //animator.SetTrigger("2-3");
        //animator.SetBool("Estado1", true);
        tronco.transform.position = Vector2.MoveTowards(tronco.transform.position, alturaTres.transform.position, velocidade);
    }

}
