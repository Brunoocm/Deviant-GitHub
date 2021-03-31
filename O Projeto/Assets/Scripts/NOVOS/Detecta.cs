using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecta : MonoBehaviour
{
    public bool podeSubir;

    private void Update()
    {
        ControlePlayers.filhoDetecta = podeSubir;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CostasPai")) podeSubir = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CostasPai")) podeSubir = false;
    }

}
