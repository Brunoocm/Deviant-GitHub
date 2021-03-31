using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BixuTrigger : MonoBehaviour
{
    public GameObject Bixu;
    public BoxCollider2D coll;
    Animator AnimatorBixu;

    void Awake()
    {
        AnimatorBixu = Bixu.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.gameObject.CompareTag("Pai") || other.gameObject.CompareTag("Filho"))
        {
            AnimatorBixu.SetTrigger("Andando");
            coll.enabled = false;
        }
    }
}
