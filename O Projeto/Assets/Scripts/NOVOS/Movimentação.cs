 using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimentação : MonoBehaviour
{
    [Header("MOVIMENTAÇÃO")]
    public bool prologo;
    [Range(1, 10)]
    public float velocidadePulo;
    [Range(1, 10)]
    public float velocidade;
    [Range(0, 1)]
    public float checkRaio;
    [Range(0, 1)]
    public float variaçãoDaVel;
    public LayerMask layerTeto;
    public Transform headPos;
    public Transform feetPos;
    public BoxCollider2D agachar;
    public bool ativo;
    public bool isFacingRight;
    public bool isFacingLeft;
    private bool direita;
    private bool esquerda;

    [Header("Size")]
    public float CollPosX;
    public float CollPosY;
    public float CollOffset;

    [Header("ANIMAÇÃO")]
    public Animator animator;
    public RuntimeAnimatorController Player1;
    public RuntimeAnimatorController PF;

    [Header("ARRASTAR")]
    public LayerMask layerChao;
    public LayerMask layerArrastavel;
    public float distancia = 1f;

    [Header("SOM")]
    public Transform MainCamera;

    //Variaveis Privadas
    private bool noChao;
    private float moveInput;
    private bool podeLevantar;
    private bool canJump;
    private bool agachado;
    private float velOrig;
    private float velPuloOrig;
    GameObject caixa;
    Rigidbody2D rb;
    SpriteRenderer sprite;

    //AudioWalk
    public AudioClip PaiFootStep1;
    public AudioClip PaiFootStep2;
    public AudioClip PaiFootStep3;
    public AudioClip[] PaiFootStepArray;
    //AudioWALK 

    //morteIguru
    public static bool MutanteVendo;
    public static bool naCaixa;
    public bool Pai;
    //morteIguru

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
        AudioSource.PlayClipAtPoint(PaiFootStep3, new Vector3((int)MainCamera.transform.position.x, 0, -40));
    }
    //AudioWALK End

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        velOrig = velocidade;
        velPuloOrig = velocidadePulo;
        isFacingLeft = false;
    }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (gameObject.GetComponent<Ativo>().enabled == true) ativo = true;
        else ativo = false;

        canJump = Physics2D.OverlapCircle(feetPos.position, checkRaio, layerChao);
        

        Physics2D.IgnoreLayerCollision(8, 9);
        Physics2D.IgnoreLayerCollision(8, 13);
        Physics2D.IgnoreLayerCollision(13, 9);
        Vector3 characterScale = transform.localScale;

        if (ControlePlayers.SetAnimation)
        {
            animator.runtimeAnimatorController = PF as RuntimeAnimatorController;
        }
        if (!ControlePlayers.SetAnimation)
        {
            animator.runtimeAnimatorController = Player1 as RuntimeAnimatorController;
        }

        //morteIguru
        if (MutanteVendo && !naCaixa && Pai)
        {
            //setar animação morte
            animator.SetTrigger("MorteHiguru");
            MutanteVendo = false;
            naCaixa = false;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            gameObject.GetComponent<Movimentação>().enabled = false;
        }
        //morteIguru

        if (ativo)
        {
            sprite.color = new Color(1, 1, 1);
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                isFacingRight = false;
                isFacingLeft = true;
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                isFacingRight = true;
                isFacingLeft = false;
            }
            if (isFacingRight) characterScale.x = 1;
            if (isFacingLeft) characterScale.x = -1;

            moveInput = Input.GetAxisRaw("Horizontal");

            if (Input.GetKeyDown("s") && !prologo || Input.GetKeyDown(KeyCode.DownArrow) && !prologo)
            {
                if (!agachado)//AGACHA
                {
                    agachar.size = new Vector2(CollPosX, CollPosY / 2);
                    agachado = true;
                    animator.SetBool("Idle", true);
                    animator.SetBool("IsCrouchingIdle", true);
                    velocidade = velOrig * variaçãoDaVel;
                }
                else if(!podeLevantar) //LEVANTA
                {
                    agachar.size = new Vector2(CollPosX, CollPosY * 2);
                    agachar.offset = new Vector2(0f, CollOffset);
                    agachado = false;
                    animator.SetBool("Idle", false);
                    animator.SetBool("IsCrouchingIdle", false);
                    velocidade = velOrig;
                }
            }
        }
        else
        {
            moveInput = 0;
            sprite.color = new Color(0.4f, 0.4f, 0.4f);
        }

        if(agachado)
        {
            podeLevantar = Physics2D.OverlapCircle(headPos.position, checkRaio, layerTeto);
        }
        else
        {
            podeLevantar = true;
        }

        transform.localScale = characterScale;

        //CONTROLE ANIMAÇÃO
        if (ativo && canJump && Input.GetButtonDown("Jump") && !prologo)
            rb.velocity = Vector2.up * velocidadePulo;

        if (rb.velocity.x == 0 && rb.velocity.y < 0.5)
            animator.SetBool("Idle", true);

        if (rb.velocity.y > 0.2) animator.SetBool("IsJumping", true);
        else animator.SetBool("IsJumping", false);

        if (rb.velocity.y < 0) animator.SetBool("IsFalling", true);
        else animator.SetBool("IsFalling", false);
        //FIM CONTROLE



        //Agarrar
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distancia, layerArrastavel);

        if (isFacingRight)
        {
            if (rb.velocity.y == 0 && hit.collider != null && hit.collider.gameObject.tag == "pushable" && Input.GetKeyDown(KeyCode.E))
            {
                caixa = hit.collider.gameObject;

                caixa.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
                caixa.GetComponent<FixedJoint2D>().enabled = true;
                caixa.GetComponent<BoxPush>().beingPushed = true;

                velocidadePulo = 0;
                animator.SetBool("IsPushing", true);
                direita = true;
            }
        }
        if (direita && Input.GetKeyDown("left") || direita && Input.GetKey("a"))
        {
            caixa.GetComponent<FixedJoint2D>().enabled = false;
            caixa.GetComponent<BoxPush>().beingPushed = false;
            velocidadePulo = velPuloOrig;
            animator.SetBool("IsPushing", false);
            direita = false;
        }

        if (isFacingLeft)
        {
            if (rb.velocity.y == 0 && hit.collider != null && hit.collider.gameObject.tag == "pushable" && Input.GetKeyDown(KeyCode.E))
            {
                caixa = hit.collider.gameObject;

                caixa.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
                caixa.GetComponent<FixedJoint2D>().enabled = true;
                caixa.GetComponent<BoxPush>().beingPushed = true;

                velocidadePulo = 0;
                animator.SetBool("IsPushing", true);
                esquerda = true;
            }
        }
        if (esquerda && Input.GetKeyDown("right") || esquerda && Input.GetKey("d"))
        {
            caixa.GetComponent<FixedJoint2D>().enabled = false;
            caixa.GetComponent<BoxPush>().beingPushed = false;
            velocidadePulo = velPuloOrig;
            animator.SetBool("IsPushing", false);
            esquerda = false;
        }
        //TerminaAgarrar


    }

    //morteIguru
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (Pai)
        {
            if (other.gameObject.CompareTag("Morte"))
            {
                MutanteVendo = true;
            }

            if (other.gameObject.CompareTag("Seguro"))
            {
                naCaixa = true;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (Pai)
        {
            if (other.CompareTag("Seguro"))
            {
                naCaixa = false;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Escolhas"))
        {
            velocidade = 0;
            velocidadePulo = 0;
            StartCoroutine(BackToIdle());
            StartCoroutine(Fall());
        }
    }

    //morteIguru
    public void Morrer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void FixedUpdate()
    {
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        animator.SetFloat("IsCrouching", Mathf.Abs(moveInput));
        rb.velocity = new Vector2(moveInput * velocidade, rb.velocity.y);
    }
    IEnumerator BackToIdle()
    {
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("Idle", true);
        animator.SetFloat("Speed", 0f);
        gameObject.GetComponent<Movimentação>().enabled = false;


    }
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(10f);
        gameObject.GetComponent<Movimentação>().enabled = true;
        velocidade = 1;
        velocidadePulo = 1;


    }


    private void OnDrawGizmos()
    {

    }
}
