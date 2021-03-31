using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimacaoMorte : MonoBehaviour
{
    public Animator anim;
    public bool Filho;

    Rigidbody2D rb;

    void OnAwake()
    {

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Agentes"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            anim.SetTrigger("MorteAgente");
            gameObject.GetComponent<Movimentação>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Maquina"))
        {
            if (Filho)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                gameObject.GetComponent<Movimentação>().enabled = false;
                StartCoroutine(WaitMorte());
                SoundEffectManager.Instance.MakeEsmaga();
            }
        }
    }

    void MortePorAgentes()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator WaitMorte()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
