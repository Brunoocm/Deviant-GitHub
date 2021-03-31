using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Iniimigos : MonoBehaviour
{
    public float velocidade = 10f;
    public Transform jogador;
    public Transform subida;
    public Animator animator;

    public bool andando;
    public bool climbing;
    public bool floresta;

    private Rigidbody2D rb;

    public float Timer;

    private void Start()
    {

    }

    private void Update()
    {
        Timer -= Time.deltaTime;

        if (andando && Timer <= 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(jogador.position.x, transform.position.y), velocidade * Time.deltaTime);
            climbing = false;
            animator.SetBool("Idle", false);
        }
        if(Timer <= 0 && Timer >= -1)
        {
            andando = true;
        }
        if (climbing)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(subida.position.x, subida.position.y), velocidade * Time.deltaTime);
            animator.SetTrigger("Climbing");
        }
        if(Timer <= -14 && floresta)
        {
            andando = false;
            animator.SetBool("Idle", true);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pai") || other.gameObject.CompareTag("Filho"))
        {
            animator.SetBool("Idle", true);
            animator.SetTrigger("Attaking");
            andando = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ar"))
        {
            animator.SetBool("Idle", true);
            andando = false;
        }
    }



}