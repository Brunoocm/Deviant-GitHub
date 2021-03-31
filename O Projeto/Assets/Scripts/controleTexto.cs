using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controleTexto : MonoBehaviour
{
    public GameObject textos;
    public Text nomeFaseTexto;
    public Text descricaoFaseTexto;
    public string nomeFase;
    public string descricaoFase;
    public float duraçãoTexto;

    private float timer;
    private bool colidindo;

    private void Awake()
    {
        nomeFaseTexto.text = nomeFase;
        descricaoFaseTexto.text = descricaoFase;
    }

    private void Update()
    {
        if (colidindo) timer += Time.deltaTime;

        if (timer + 1 > 0 && timer + 1 < duraçãoTexto)
        {
            textos.SetActive(true);
        }
        else
        {
            textos.SetActive(false);
            Destroy(textos);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pai") || collision.gameObject.CompareTag("Filho")) 
        {
            colidindo = true;
        }
    }


}
