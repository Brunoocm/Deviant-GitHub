using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arvoreCresce : MonoBehaviour
{
    public GameObject alturaFinal;
    public float velCresce;
    private float step;
    Rigidbody2D rb;

    private Vector2 alturaFinal_;
    private bool cresce;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        alturaFinal_ = new Vector2(alturaFinal.transform.position.x, alturaFinal.transform.position.y);
        step =  velCresce * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, alturaFinal_, velCresce);

        if (!enabled) transform.position = new Vector2(0, 0); 
    
    }
}
