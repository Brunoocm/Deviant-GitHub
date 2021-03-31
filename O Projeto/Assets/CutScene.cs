using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CutScene : MonoBehaviour
{
    public Animator anim;
    public bool Ruim;
    public GameObject Timer;
    public GameObject Pai;
    void Start()
    {
        Ruim = false;
    }


    void Update()
    {
        if(Ruim)
        {
            
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Pai"))
        {
            StartCoroutine(ProxCutSceneBoa());
            anim.SetTrigger("Boa");
            Pai.SetActive(false);
        }
    }

    public void Ativa()
    {
        StartCoroutine(ProxCutSceneRuim());
        anim.SetTrigger("Ruim");
        Timer.SetActive(false);
    }

    IEnumerator ProxCutSceneBoa()
    {
        yield return new WaitForSeconds(25);
        SceneManager.LoadScene("Menu");

    }

    IEnumerator ProxCutSceneRuim()
    {
        yield return new WaitForSeconds(25);
        SceneManager.LoadScene("Menu");

    }


}
