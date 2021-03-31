using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cheat : MonoBehaviour
{
    public GameObject parametrização;

    private bool ativo;

    private void Start()
    {
        ativo = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Prólogo");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Fase Prédios");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Ferro Velho");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("Escolhas");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene("FaseMutantes");
        }

        if(Input.GetKeyDown("p"))
        {
            if (ativo) ativo = false;
            else ativo = true;
        }


        if(ativo)
        {
            parametrização.SetActive(false);
        }
        else if(!ativo)
        {
            parametrização.SetActive(true);
        }
    }


}
