using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderArvore : MonoBehaviour
{
    void Update()
    {
        Physics2D.IgnoreLayerCollision(2,9);
        Physics2D.IgnoreLayerCollision(2,8);

    }
}
