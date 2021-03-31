using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleAntena : MonoBehaviour
{
    public GameObject AntenaEmPé;
    public GameObject AntenaCaida;
    public GameObject Pai;
    public float duraçãoInteração;
    public float duraçãoAnimação;
    public Animator animator;

    private bool ativo;
    private float timer;
    private float timer2;
    private bool startaTimer;
    private float startaAnim;

    private void Update()
    {

        //detecta se o pai está ativo e está apertando f
        if (Input.GetKeyDown("e"))
        {
            if (ativo && Pai.GetComponent<Ativo>().enabled) startaTimer = true;
        }
        if (Input.GetKeyUp("e")) startaTimer = false;
        //fim detecta f

        //timer de controle do tempo que pressionou "f"
        if (startaTimer) timer += Time.deltaTime;

        //verifica se o timer ja passou a duracao da animacao e aciona a acao de troca de objetos
        if(timer >= duraçãoInteração) startaAnim += Time.deltaTime;


        if(startaAnim >= duraçãoAnimação)
        {
            AntenaEmPé.SetActive(false);
            animator.SetBool("IsFall",true);
            AntenaCaida.SetActive(true);
            
        }        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Pai")
        {
            ativo = true;
        }
    }
     
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pai")
        {
            ativo = false;
        }
    }
}
