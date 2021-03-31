using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastPos : MonoBehaviour
{

    private ObjectCheck check;
    void Start()
    {
        //Checkpoint
        check = GameObject.FindGameObjectWithTag("Ocheck").GetComponent<ObjectCheck>();
        transform.position = check.lastCheckPointPos;
        //Checkpoint
    }
    void Update()
    {
        //ativar o Spawn manualmente 
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}
        //Checkpoint
    }
}
