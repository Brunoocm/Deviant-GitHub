using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerJornal : MonoBehaviour
{
    [SerializeField]
    private Image customImage;
    [SerializeField]
    private Image JornalImage;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Pai"))
        {
            customImage.enabled = true;
            if(customImage.enabled == true && Input.GetKey("d"))
            {
                JornalImage.enabled = true;
                customImage.enabled = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Pai"))
        {
            if (Input.GetKey("d"))
            {
                JornalImage.enabled = true;
                customImage.enabled = false;
            }
        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Pai"))
        {
            customImage.enabled = false;
            JornalImage.enabled = false;
        }
    }

}
