using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroScroll : MonoBehaviour
{
    float Speed = 25f;
    Vector2 Pos;

    void Start()
    {
        Pos = transform.position;
    }

    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * Speed, 480);
        transform.position = Pos + Vector2.left * newPos;
    }
}
