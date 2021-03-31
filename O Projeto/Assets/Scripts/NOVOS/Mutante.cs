using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mutante : MonoBehaviour
{
    public BoxCollider2D boxCol;
    public BoxCollider2D boxCol2;
    public BoxCollider2D boxCol3;
    public Animator anim;
    public Movimentação pai;

    void Awake()
    {
        boxCol3.enabled = false;
    }
    void Update()
    {
    }


    void BixuAtaque()
    {
        boxCol.enabled = true;
        boxCol2.enabled = true;
    }

    void BixuAtaque2()
    {
        boxCol3.enabled = true;
        boxCol.enabled = true;
    }

    void BixuAtaqueDisabled()
    {
        boxCol.enabled = false;
        boxCol2.enabled = false;
        boxCol3.enabled = false;

        Movimentação.MutanteVendo = false;
    }
}
