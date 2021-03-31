using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arvoreDiminui : MonoBehaviour
{
    public GameObject alturaInicial;
    public float velCresce;
    private float step;
    Rigidbody2D rb;

    private Vector2 alturaInicial_;
    private bool diminui;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        alturaInicial_ = new Vector2(alturaInicial.transform.position.x, alturaInicial.transform.position.y);
        step = velCresce * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, alturaInicial_, velCresce);

        if (!enabled) transform.position = new Vector2(0, 0);

    }
}
