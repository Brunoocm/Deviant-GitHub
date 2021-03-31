using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento : MonoBehaviour
{

    public bool ativo;
    public bool doisAtivos;
    private bool eraAtivo;

    public Collider2D agachar;
    public GameObject agacharObj;

    [Range(1, 10)]
    public float velPulo;
    [Range(1, 10)]
    public float velQueda;
    public float distChao = 0.05f;
    public LayerMask layerChao;
    public LayerMask layerPlayer;

    public float velocidade;
    private float moveInput;

    bool jump;
    bool grounded;
    bool player;

    Vector2 playerSize;
    Vector2 boxSize;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSize = GetComponent<BoxCollider2D>().size;
        boxSize = new Vector2(playerSize.x, distChao);
    }

    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (ativo) ativo = false;
            else ativo = true;
        }
        if (Input.GetKeyDown("q"))
        {
            if (doisAtivos) doisAtivos = false;
            else doisAtivos = true;
        }   



        if (ativo || doisAtivos) {

            if (Input.GetButton("Jump") && grounded)
            {
                jump = true;
            }

           /* if (Input.GetButton("Jump") && player)
            {
                jump = true;
            }*/


            if (Input.GetKeyDown("tab"))
            {
                if (agachar.enabled)
                {
                    agachar.enabled = false;
                    agacharObj.SetActive(false);
                }
                else
                {
                    agacharObj.SetActive(true);
                    agachar.enabled = true;
                }
            }
        }
        
    }

    private void FixedUpdate()
    {

        if (jump)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * velPulo, ForceMode2D.Impulse);
            jump = false;
            grounded = false;
        } 
        else
        {
            Vector2 boxCenter = (Vector2)transform.position + Vector2.down * (playerSize.y + boxSize.y) * 0.5f;
            grounded = (Physics2D.OverlapBox(boxCenter, boxSize, 0f, layerChao) != null);
        }

        if (jump)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * velPulo, ForceMode2D.Impulse);
            jump = false;
            player = false;
        }
        else
        {
            Vector2 boxCenter = (Vector2)transform.position + Vector2.down * (playerSize.y + boxSize.y) * 0.5f;
            player = (Physics2D.OverlapBox(boxCenter, boxSize, 0f, layerPlayer) != null);
        }

        if (rb.velocity.y < 0)
        {
            rb.gravityScale = velQueda;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.gravityScale = velQueda;
        } else
        {
            rb.gravityScale = 1f;

        }

        if (ativo || doisAtivos)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
        }
        rb.velocity = new Vector2(moveInput * velocidade, rb.velocity.y);
    }
}
