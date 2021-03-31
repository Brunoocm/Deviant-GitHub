using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eletroJunkies : MonoBehaviour
{

    public GameObject letreiro;

    private float valor;
    private float timer;
    private bool ativo;

    private void Start()
    {
        valor = Random.Range(0.5f, 3);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= valor && ativo == false)
        {
            Valor();
            Ativa();
            ativo = true;
            timer = 0;
        }
        else if (timer >= valor && ativo == true)
        {
            Valor();
            Desativa();
            ativo = false;
            timer = 0;
        }

    }

    public void Ativa()
    {
        letreiro.SetActive(true);
    }

    public void Desativa()
    { 
        letreiro.SetActive(false);
    }

    public void Valor()
    {
        valor = Random.Range(0.5f, 3);
    }
}
