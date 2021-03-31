using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleArvore : MonoBehaviour
{
    public ControlePlayers controleDePlayers;
    public GameObject tronco;
    public BoxCollider2D collider2D;
    public Transform alturaUm;
    public Transform alturaDois;
    public float duraçãoInteracao;
    public GameObject travaCano;
    [Range(0, 10)]
    public float velTronco;
    public Animator animator;

    private float velocidade;
    private int estado = 2;
    private bool ativo;
    private bool podeTrocar;

    private void Start()
    {
        podeTrocar = true;
    }

    private void Update()
    {
        velocidade = velTronco * Time.deltaTime;

        if (Input.GetKeyDown("q") && ativo && podeTrocar)
        {
            podeTrocar = false;

            if (estado == 1)
            {
                estado = 2;
                SoundEffectManager.Instance.MakeCrescer();
            }
            else if (estado == 2) estado = 1;
            SoundEffectManager.Instance.MakeDiminui();
        }

        if (estado == 1)
        {
            estadoUm();
        }
        else if (estado == 2) estadoDois();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Filho" || collision.gameObject.CompareTag("Pai") && controleDePlayers.nasCostas) ativo = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Filho") ativo = false;
        if (collision.gameObject.CompareTag("Pai")) ativo = false;
    }


    void estadoUm()
    {
        animator.SetBool("Volta", true);
        tronco.transform.position = Vector2.MoveTowards(tronco.transform.position, alturaUm.transform.position, velocidade);
        travaCano.SetActive(false);
        collider2D.enabled = false;
        //Collider Some
    }

    void estadoDois()
    {
        animator.SetBool("Volta", false);
        tronco.transform.position = Vector2.MoveTowards(tronco.transform.position, alturaDois.transform.position, velocidade);
        travaCano.SetActive(true);
        if(collider2D != null)
            collider2D.enabled = true;
    }

    public void PodeTrocar()
    {
        podeTrocar = true;
    }

}
