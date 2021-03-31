using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAI : MonoBehaviour
{
    Rigidbody2D rb;

    private bool isClimbing;
    private float inputVertical;
    public LayerMask whatIsLadder;
    public float distance;
    
    
    public bool ativo;
    public bool doisAtivos;
    private bool eraAtivo;

    public Animator animator;

    public Collider2D agachar;
   
    //Push
    public LayerMask boxMask;
    public float distanceBox = 1f;
    //PushEnd

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

    public GameObject filho;


    GameObject Box;

    //AudioWalk

    public AudioClip PaiFootStep1;

    public AudioClip PaiFootStep2;

    public AudioClip PaiFootStep3;

    public AudioClip[] PaiFootStepArray;
    
    public void PaiRandomSound()
    {
        int randomType = UnityEngine.Random.Range(0, 2);
        AudioSource.PlayClipAtPoint(PaiFootStepArray[randomType], new Vector3((int)MainCamera.transform.position.x, 0, -40));
    }

    public void PaiFootStepfunction1()
    {
        AudioSource.PlayClipAtPoint(PaiFootStep1, new Vector3((int)MainCamera.transform.position.x, 0, -40));
    }

    public void PaiFootStepfunction2()
    {
        AudioSource.PlayClipAtPoint(PaiFootStep2, new Vector3((int)MainCamera.transform.position.x, 0, -40));
    }

    public void PaiFootStepfunction3()
    {
        AudioSource.PlayClipAtPoint(PaiFootStep3, new Vector3((int)MainCamera.transform.position.x , 0, -40));
    }
    //AudioWALK End

    public void AnimationSoco()
    {
        animator.SetBool("IsPunching", false);
    }


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
                animator.SetFloat("IsCrouching", 0f);
            }
        }

        if (Input.GetKeyDown("q")) //ativa ou desativa os controle conjunto
        {
            if (ativo) ativo = false;
            else ativo = true;

            if (rb.velocity.x == 0 && rb.velocity.y == 0) 
            {
                animator.SetBool("Idle", true);
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", false);
                animator.SetFloat("Speed", 0f);
                animator.SetFloat("IsCrouching", 0f);
            }

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("IsPunching", true);
        }

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
            animator.SetBool("IsPunching", false);
            animator.SetFloat("Speed", 0f);
            animator.SetFloat("IsCrouching", 0f);
            velocidade = 0f;
        }
        else
        {
            velocidade = 3f;
        }

        transform.localScale = characterScale;

        if (ativo || doisAtivos)
        {

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
                animator.SetFloat("IsCrouching", 0f);
            }

            if (Input.GetKeyDown("tab"))
            {
                if (agachado)
                {
                    //AGACHA
                    agachar.enabled = false;
                    agachado = false;
                    animator.SetBool("IsCrouchingIdle", true);
                    animator.SetBool("Idle", false);

                    if (rb.velocity.x == 0)
                    {
                        animator.SetBool("IsCrouchingIdle", true);
                    }
                    if (rb.velocity.x > 0)
                    {
                        animator.SetFloat("IsCrouching", 1f);
                    }
                }
                else
                {
                    //LEVANTA
                    agachar.enabled = true;
                    agachado = true;
                    animator.SetBool("IsCrouchingIdle", false);
                    animator.SetBool("Idle", true);
                    
                }
            }
        }

        //Push
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distanceBox, boxMask);

        if (ativo || doisAtivos)
        {
            if (rb.velocity.y == 0 && hit.collider != null && hit.collider.gameObject.tag == "pushable" && Input.GetKeyDown(KeyCode.Z))
            {
                Box = hit.collider.gameObject;

                Box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
                Box.GetComponent<FixedJoint2D>().enabled = true;
                Box.GetComponent<BoxPush>().beingPushed = true;

                jumpVel = 0;
                animator.SetBool("IsPushing", true);
            }
            else if (Input.GetKeyUp(KeyCode.Z))
            {
                Box.GetComponent<FixedJoint2D>().enabled = false;
                Box.GetComponent<BoxPush>().beingPushed = false;

                jumpVel = 6;
                animator.SetBool("IsPushing", false);
            }
        }
        //PushEnd
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
            animator.SetFloat("IsCrouching", Mathf.Abs(moveInput));
        }
        else
        {
            animator.SetFloat("IsCrouching", 0f);
            animator.SetFloat("Speed", 0f);
        }
        rb.velocity = new Vector2(moveInput * velocidade, rb.velocity.y);

    }
}
