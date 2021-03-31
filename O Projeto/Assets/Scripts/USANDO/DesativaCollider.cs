using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesativaCollider : MonoBehaviour
{
    public BoxCollider2D Coll;
    public BoxCollider2D Coll2;
    public BoxCollider2D Coll3;
    public BoxCollider2D Escolhas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Maquina"))
        {
            Coll.enabled = false;
            Coll2.enabled = false;
            Coll3.enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pai"))
        {
            Escolhas.enabled = false;
        }
    }
}
