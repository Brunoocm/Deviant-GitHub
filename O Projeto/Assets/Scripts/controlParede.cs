using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlParede : MonoBehaviour
{
    public Collider2D parede;
    public bool paredeFilho;
    public GameObject AR;
    public ControlePlayers controleDePlayers;

    public Animator animator;
    private bool paredeAtiva;
    private bool filhoAtivo;
    private bool paiAtivo;


    private void Awake()
    {

    }

    private void Update()
    {
        if (filhoAtivo)
        {
            if (filhoAtivo && Input.GetKeyDown("q") && !paredeAtiva && paredeFilho)
            {
                animator.SetBool("Ativa", false);
                SoundEffectManager.Instance.MakeCrescer();
            }
            if (filhoAtivo && Input.GetKeyDown("q") && paredeAtiva && paredeFilho)
            {
                animator.SetBool("Ativa", true);
                SoundEffectManager.Instance.MakeDiminui();
            }
        }

        if (paiAtivo)
        {
            if (paiAtivo && Input.GetKeyDown("e") && !paredeAtiva && !paredeFilho)
            {
                animator.SetBool("Ativa", true);
            }
            if (paiAtivo && Input.GetKeyDown("e") && paredeAtiva && !paredeFilho)
            {
                animator.SetBool("Ativa", true);
            }
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Filho") || collision.gameObject.CompareTag("Pai") && controleDePlayers.nasCostas)
        {
            filhoAtivo = true;
        }

        if (collision.gameObject.CompareTag("Pai"))
        {
            paiAtivo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Filho"))
        {
            filhoAtivo = false;
        }

        if (collision.gameObject.CompareTag("Pai"))
        {
            filhoAtivo = false;
            paiAtivo = false;
        }
    }

    public void AtivaParede()
    {
        parede.enabled = true;
        paredeAtiva = true;
    }

    public void DesativaParede()
    {
        parede.enabled = false;
        paredeAtiva = false;
    }

    public void DesativaParede2()
    {
        parede.enabled = false;
        paredeAtiva = true;
        if(AR != null)
        AR.SetActive(false);
    }

    public void AtivaParede2()
    {
        parede.enabled = true;
        paredeAtiva = false;
        if(AR !=null)
        AR.SetActive(true);
    }


}
