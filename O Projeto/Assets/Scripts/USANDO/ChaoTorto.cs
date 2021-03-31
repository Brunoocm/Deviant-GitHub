using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoTorto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(14, 9);
        Physics2D.IgnoreLayerCollision(14, 8);
    }
}
