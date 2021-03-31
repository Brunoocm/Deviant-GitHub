using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alavanca : MonoBehaviour
{
    public Animator animator;

    public bool detecta;

    private void Update()
    {
        if(detecta && Input.GetKeyDown("e"))
        {
            animator.SetTrigger("Ativa");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Filho")
        {
            detecta = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detecta = false;
    }

}
