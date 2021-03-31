using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rato : MonoBehaviour
{
    public GameObject ratoObjeto;

    private void Start()
    {
        ratoObjeto.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Filho") || collision.gameObject.CompareTag("Pai"))
        {
            ratoObjeto.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = false;
        }
            
    }

}
