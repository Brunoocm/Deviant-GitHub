using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onibus : MonoBehaviour
{
    private Animator animator;
    public GameObject onibus2;

    private void Start()
    {
        animator = GetComponent<Animator>();
        onibus2.SetActive(false);
    }

    public void OnibusSobe()
    {
        animator.SetTrigger("sobe");
    }

    public void AtivaOnibus()
    {
        onibus2.SetActive(true);
        this.gameObject.SetActive(false);
    }


}
