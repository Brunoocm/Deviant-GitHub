using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Costas : MonoBehaviour
{
    public GameObject filho;
    public bool colidindo;
    private bool volta;


    public void Update()
    {
        if (Input.GetKeyDown("q") && colidindo)
        {
            filho.SetActive(false);
            volta = true;
        }
        else if(Input.GetKeyDown("q") && volta)
        {
            filho.SetActive(true);
            volta = false;
            filho.transform.position = transform.position;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Filho")
        {
            colidindo = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        colidindo = false;
    }
}
