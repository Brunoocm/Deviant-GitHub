using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private ObjectCheck check;

    void Start()
    {
        check = GameObject.FindGameObjectWithTag("Ocheck").GetComponent<ObjectCheck>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Pai") || other.CompareTag("Filho"))
        {
            check.lastCheckPointPos = transform.position;
        }
    }

}
