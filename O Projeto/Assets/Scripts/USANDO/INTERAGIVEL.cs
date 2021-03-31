using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTERAGIVEL : MonoBehaviour
{
    public bool colidindo;
    public Collider2D trigger;
    public GameObject obj;
    public GameObject obj2;
    public GameObject obj3;
    [Range(0,2)]
    public int estado = 1;

    public Animator animator;

    public void Update()
    {
        if(estado == 0)
        {
            obj.SetActive(false);
            obj2.SetActive(true);
            obj3.SetActive(false);
        }
        else if(estado == 1)
        {
            obj.SetActive(true);
            obj2.SetActive(false);
            obj3.SetActive(false);
        }
        else if(estado == 2)
        {
            obj.SetActive(false);
            obj2.SetActive(false);
            obj3.SetActive(true);
        }

        if(colidindo)
        {
            if (Input.GetKeyDown("c"))
            {
                estado--;
                animator.SetBool("IsPowerP", true);
            }
            if (Input.GetKeyDown("x"))
            {
                estado++;
                animator.SetBool("IsPowerF", true);
            }          
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == null) colidindo = false;
        if (collision.gameObject.tag == "Filho")
        {
            colidindo = true;
        }   
    }
}
