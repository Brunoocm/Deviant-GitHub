using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlavancaPortao : MonoBehaviour
{
    public GameObject portao;
    //public Animator animator;

    private bool detecta;
    private bool ativa;

    private void Start()
    {
        ativa = false;
    }

    private void Update()
    {
        if(detecta)
        {
            if(Input.GetKeyDown("e"))
            {
                ativa = !ativa;
            }
        } 
        
        if(ativa)
        {
            portao.SetActive(false);
        }
        else
        {
            portao.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pai" || collision.gameObject.tag == "Filho") detecta = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detecta = false;
    }

}
