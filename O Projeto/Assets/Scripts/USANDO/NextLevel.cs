using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    [SerializeField] 
    private Image customImage;
    public Animator anim;
    private bool parar;
    private bool Tecla;
    public GameObject Pai;

    void Start()
    {
        parar = true;
        Tecla = false;
    }

    void Update()
    {
        if (Tecla && Input.GetKeyDown("e"))
        {
            StartCoroutine(ProxCutScene());
            anim.SetTrigger("Prologo");
            parar = false;
            Tecla = false;
            Pai.SetActive(false);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    { 
        if(col.CompareTag("Pai"))
        {
            customImage.enabled = true;
            Tecla = true;

        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Pai"))
        {
            customImage.enabled = false;
            Tecla = false;
        }
    }

    IEnumerator ProxCutScene()
    {
        yield return new WaitForSeconds(45);
        SceneManager.LoadScene("Fase Prédios");


    }
}
