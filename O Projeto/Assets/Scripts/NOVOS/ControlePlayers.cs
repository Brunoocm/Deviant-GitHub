using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePlayers : MonoBehaviour
{
    public bool prologo;
    public GameObject Pai;
    public GameObject Filho;
    public GameObject costasPai;

    [Range(1,10)]
    public float velocidadeFilho;
    public static bool paiActive;
    public static bool filhoActive;
    public static bool SetAnimation;
    public float apertarDuração;
    public bool paiAtivo;
    public bool filhoAtivo;
    public bool comecaNasCostas;

    public float timer = 0f;
    //[HideInInspector]
    public static bool filhoDetecta;
    public bool detectaCostas;
    private bool startaTimer;
    [HideInInspector]
    public bool nasCostas;
    

    void Awake()
    {
        SetAnimation = false;
        paiAtivo = true;
        if(comecaNasCostas)
        {
            nasCostas = true;
        }
    }

    void Update()
    {
        detectaCostas = filhoDetecta;
        paiActive = paiAtivo;
        filhoActive = filhoAtivo;


        if (!prologo)
        {
            if (Input.GetKeyDown("f"))
            {
                startaTimer = true;

                if (paiAtivo)
                {
                    Pai.GetComponent<Ativo>().enabled = false;
                    paiAtivo = false;
                }
                else if (!paiAtivo)
                {
                    Pai.GetComponent<Ativo>().enabled = true;
                    paiAtivo = true;
                }
                if (filhoAtivo)
                {
                    Filho.GetComponent<Ativo>().enabled = false;
                    filhoAtivo = false;
                }
                else if (!filhoAtivo)
                {
                    Filho.GetComponent<Ativo>().enabled = true;
                    filhoAtivo = true;
                }

                if (Filho.activeSelf == false && Pai.activeSelf == true)
                {
                    Filho.transform.position = Pai.transform.position;
                    Filho.SetActive(true);
                    SetAnimation = false;
                    Pai.GetComponent<Ativo>().enabled = false;
                    Filho.GetComponent<Ativo>().enabled = true;
                    nasCostas = false;
                    timer = 0;
                    filhoAtivo = true;
                }
            }
            else if (Input.GetKeyUp("f"))
            {
                startaTimer = false;
            }
        }
        
        if(startaTimer) timer += Time.deltaTime;
        else timer = 0;

        if (timer >= apertarDuração && detectaCostas) nasCostas = true;


        if (nasCostas)
        {
            //animaçãoPaieFilho
            paiAtivo = true;
            SetAnimation = true;
            Filho.SetActive(false);
            Filho.GetComponent<Ativo>().enabled = false;
            Pai.GetComponent<Ativo>().enabled = true;
            timer = 0;
        }
    }
}
