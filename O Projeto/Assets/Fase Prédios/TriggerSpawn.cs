using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawn : MonoBehaviour
{
    public GameObject Agentes;
    public GameObject PortaFechada;
    public GameObject PortaAberta;
    [Range(0,3)]
    public float atrasoSpawn;
    private float timer;
    private bool ativo;

    private void Awake()
    {
        Agentes.SetActive(false);
    }

    private void Update()
    {
        if(ativo)
        {
            timer += Time.deltaTime;
        }

        if(timer >= atrasoSpawn)
        {
            Agentes.SetActive(true);
            PortaFechada.SetActive(false);
            StartCoroutine(PortaFechadaWait());
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Pai" || collision.gameObject.tag == "Filho")
        {
            ativo = true;
        }
    }

    IEnumerator PortaFechadaWait()
    {
        yield return new WaitForSeconds(0.8f);
        PortaAberta.SetActive(true);
    }

}
