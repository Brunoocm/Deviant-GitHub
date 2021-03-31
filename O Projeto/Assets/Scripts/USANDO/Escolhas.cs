using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Escolhas : MonoBehaviour
{
    private float Timer = 0f;
    [SerializeField]
    private float StartTimer = 10;
    private bool AtivaTimer = false;
    public Animator anim;
    public GameObject PrimeiraOpcao;
    public GameObject TimerCanvas;
    public BoxCollider2D boxColl;
    public BoxCollider2D boxCollTrigger;


    [SerializeField] Text TimerText;

    void Start()
    {
        Timer = StartTimer;
    }


    void Update()
    {
        if (AtivaTimer)
        {
            Timer -= 1 * Time.deltaTime;
            TimerText.text = Timer.ToString();
        }
        if (Timer <= 0.01)
        {
            TimerText.text = 0.00f.ToString();
            PrimeiraOpcao.SetActive(false);
            anim.SetTrigger("PonteAtiva");
            
        }
    }

    void desativa()
    {
        boxColl.enabled = false;
        SoundEffectManager.Instance.MakeMadeira();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pai"))
        {
            PrimeiraOpcao.SetActive(true);
            TimerCanvas.SetActive(true);
            AtivaTimer = true;
            boxCollTrigger.enabled = false;
            gameObject.GetComponent<Movimentação>().enabled = false;
        }
    }

}
