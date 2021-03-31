using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FILHO : MonoBehaviour
{

    Rigidbody2D rb;

    public bool ativo;
    public bool doisAtivos;
    private bool eraAtivo;

    public Animator animator;

    public Collider2D agachar;

    [Range(1, 10)]
    public float jumpVel;
    public float checkRadius;
    public Transform feetPos;
    public Transform MainCamera;
    public LayerMask layerChao;
    public bool noChao;

    [Range(1, 10)]
    public float velocidade;
    private float moveInput;

    private bool canJump;
    private bool agachado;

    //AudioWalk
    public AudioClip FilhoFootStep1;

    public AudioClip FilhoFootStep2;

    public AudioClip FilhoFootStep3;

    public AudioClip[] FilhoFootStepArray;

    public void FilhoRandomSound()
    {
        int randomType = UnityEngine.Random.Range(0, 2);
        AudioSource.PlayClipAtPoint(FilhoFootStepArray[randomType], new Vector3((int)MainCamera.transform.position.x, 0, -40));
    }

    public void FilhoFootStepfunction1()
    {
        AudioSource.PlayClipAtPoint(FilhoFootStep1, new Vector3((int)MainCamera.transform.position.x, 0, -40));
    }

    public void FilhoFootStepfunction2()
    {
        AudioSource.PlayClipAtPoint(FilhoFootStep2, new Vector3((int)MainCamera.transform.position.x, 0, -40));
    }

    public void FilhoFootStepfunction3()
    {
        AudioSource.PlayClipAtPoint(FilhoFootStep3, new Vector3((int)MainCamera.transform.position.x, 0, -40));
    }
    //AudioWALK End

    public void Awake()
    {
        animator.SetBool("Idle", true);
        rb = GetComponent<Rigidbody2D>();
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

            if (rb.velocity.x == 0 && rb.velocity.y == 0) 
            {
                animator.SetBool("Idle", true);
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", false);
                animator.SetFloat("Speed", 0f);
            }
        }

       /* if (Input.GetKeyDown("q")) //ativa ou desativa os controle conjunto
        {
            if (rb.velocity.x == 0 && rb.velocity.y == 0) ;
            {
                animator.SetBool("Idle", true);
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", false);
                animator.SetFloat("Speed", 0f);
            }
        }*/

        //se for colocar animacao de quando o personagem está desativo é só colocar um :
        /*if !(doisAtivos && ativo) 
         * {
         *      prog de anim;
         * }*/

        if (!doisAtivos && !ativo)
        {
            characterScale.x = 1;
            animator.SetBool("Idle", true);
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
            animator.SetFloat("Speed", 0f);
            velocidade = 0f;
        }
        else
        {
            velocidade = 3f;
        }

        transform.localScale = characterScale;

        if (ativo)
        {
            //Caixa
            if (rb.velocity.y == 0)
            {

                if (Input.GetKeyDown(KeyCode.Z))
                {
                    jumpVel = 0;

                    animator.SetBool("IsPushing", true);
                }

                if (Input.GetKeyUp(KeyCode.Z))
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

            if (rb.velocity.y > 0)
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
                animator.SetFloat("Speed", 0f);
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
