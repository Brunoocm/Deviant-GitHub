using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalar : MonoBehaviour
{
    Rigidbody2D rb;
    
    public Animator animator;   
    public Vector3 climbPos;

    public Transform LedgePos;
    public float timer = 0f;
    public float checkLedge;
    private bool naLedge;
    private bool canLedge;

    public LayerMask layerLedge;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        canLedge = Physics2D.OverlapCircle(LedgePos.position, checkLedge, layerLedge);

        if(timer < 2f)
        {
            canLedge = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Canto") && canLedge)
        {
            rb.bodyType = RigidbodyType2D.Static;
            animator.SetTrigger("IsClimbing");
            climbPos = GetComponent<Transform>().position;
            timer = 0f;
            gameObject.GetComponent<Movimentação>().enabled = false;
        }
    }

    void backtoidle()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Transform>().position = new Vector3(climbPos.x + 0.8f, climbPos.y + 1.3f, 0);
        animator.SetTrigger("IdleTrigger");
        gameObject.GetComponent<Movimentação>().enabled = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(LedgePos.position, checkLedge);

    }
}
