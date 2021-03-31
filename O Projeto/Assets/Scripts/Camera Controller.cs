using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    
    public GameObject Follow;

    float posI;
    float deltaX;
    
    // Start is called before the first frame update
    void Start()
    {
        posI = Follow.transform.position.x;
        deltaX = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        deltaX = Follow.transform.position.x - posI;
        posI = Follow.transform.position.x;

        //transform.Translate;        
    }
}
