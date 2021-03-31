using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controleMaquinaIma : MonoBehaviour
{
    public onibus Onibus;
    public GameObject motor;
    public GameObject imagemMotor;
    public Collider2D colliderOnibus;
    public GameObject colliderAlavanca;
    public Animator animator;

    public bool ativa;

    private void Start()
    {
        Quebrada();
        imagemMotor.SetActive(false);
    }

    private void Update()
    {
        if(ativa)
        {
            /*luzVerde.SetActive(true);
            luzVermelha.SetActive(false);*/
            animator.SetBool("funcionando", true);
            animator.SetBool("quebrada", false);
            colliderAlavanca.SetActive(true);
        }
        else if (!ativa)
        {
            /*luzVerde.SetActive(false);
            luzVermelha.SetActive(true);*/
            animator.SetBool("quebrada", true);
            animator.SetBool("funcionando", false);
            colliderAlavanca.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Motor")
        {
            if (animator != null) animator.SetBool("Funcionando", true);
            ativa = true;

            motor.SetActive(false);
            imagemMotor.SetActive(true);
        }
    }
    

    public void Quebrada ()
    {
        ativa = false;
    }
    
    public void Funcionando()
    {
        animator.SetBool("funcionando", true);
        ativa = true;
    }

    public void Ativou()
    {
        animator.SetTrigger("subindo");
        Onibus.OnibusSobe();
        SoundEffectManager.Instance.MakeMaquina();
    }
}
