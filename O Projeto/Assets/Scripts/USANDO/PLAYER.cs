using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PLAYER : MonoBehaviour
{
    Rigidbody2D rb;

    public bool ativo;
    public bool doisAtivos;
    private bool eraAtivo;

    public Animator animator;

    public Collider2D agachar;

    [Range(1,10)]
    public float jumpVel;
    public float checkRadius;
    public Transform feetPos;
    public LayerMask layerChao;
    public bool noChao;

    [Range(1,10)]
    public float velocidade;
    private float moveInput;

    private bool canJump;
    private bool agachado;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    public void Update()
    {

        canJump = Physics2D.OverlapCircle(feetPos.position, checkRadius, layerChao);

        Vector3 characterScale = transform.localScale;

        Physics2D.IgnoreLayerCollision(8, 9);

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            characterScale.x = -1;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;

        if (Input.GetKeyDown("e")) //troca individual de pers ativo
        {
            if (ativo) ativo = false;
            else ativo = true;

            if (rb.velocity.x == 0 && rb.velocity.y == 0) ;
            {
                animator.SetBool("Idle", true);
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", false);
                animator.SetFloat("Speed", 0f);
            }
        }
        
        if (Input.GetKeyDown("q")) //ativa ou desativa os controle conjunto
        {
            if (doisAtivos) doisAtivos = false;
            else doisAtivos = true;

            if (rb.velocity.x == 0 && rb.velocity.y == 0) ;
            {
                animator.SetBool("Idle", true);
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", false);
                animator.SetFloat("Speed", 0f);
            }
        }

        //se for colocar animacao de quando o personagem está desativo é só colocar um :
        /*if !(doisAtivos && ativo) 
         * {
         *      prog de anim;
         * }*/

         if (!doisAtivos && !ativo)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;

        if (ativo || doisAtivos)   
        {
            //Caixa
            if (rb.velocity.y == 0)
            {              

                if (Input.GetKeyDown(KeyCode.Z))
                {
                    jumpVel = 0;    

                    animator.SetBool("IsPushing", true);
                }

                else 
                {
                    jumpVel = 4;

                    animator.SetBool("IsPushing", false);                   
                }
            }

            if (canJump && Input.GetButtonDown("Jump"))
            {
                //PULO
                rb.velocity = Vector2.up * jumpVel;

            }

            if(rb.velocity.y > 0)
            {
                animator.SetBool("IsJumping", true);
            }
            if (rb.velocity.y == 0)
            {
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", false);
            }
            if (rb.velocity.y < 0)
            {
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", true);
            }

            if (Input.GetKeyDown("tab"))
            {
                if (agachado)
                {
                    //AGACHA
                    agachar.enabled = false;
                    agachado = false;
                    animator.SetBool("IsCrouching", true);
                }
                else
                {
                    //LEVANTA
                    agachar.enabled = true;
                    agachado = true;
                    animator.SetBool("IsCrouching", false);
                }
            }
        }
    }

    public void FixedUpdate()
    {
        
        if (ativo || doisAtivos)
        {
            //ANDAR
            //Se for fazer por controlador de velx > ou < que 0 supimpa senao le aqui embaixo que esse metodo tbm serve
            //Se quiser fazer as anims por meio de input de tecla tem que fazer outro if usando :
            //Input.GetButtonDown("d")) e outro usando Input.GetButtonDown("a"))
            moveInput = Input.GetAxisRaw("Horizontal");

            animator.SetFloat("Speed", Mathf.Abs(moveInput));
        }
        rb.velocity = new Vector2(moveInput * velocidade, rb.velocity.y);
    }

}
