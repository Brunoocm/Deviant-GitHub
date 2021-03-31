using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;

public class DialogoPF : MonoBehaviour
{
    [SerializeField]
    private Image CaixaText;

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float TimerValor;
    private float Timer;
    public float typingSpeed;

    private bool IniciaTimer;
    private bool Coroutine = false;



    void Start()
    {
        IniciaTimer = false;
    }


    void Update()
    {
        if(IniciaTimer)
        {
            Timer += Time.deltaTime;
        }
        if(Timer > TimerValor)
        {
            Continue();
            Timer = 0;
        }
        if(Coroutine)
        {
            StartCoroutine(Type());
            Coroutine = false;
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Continue()
    {
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
            textDisplay.text = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pai"))
        {
            Timer = 0;
            IniciaTimer = true;
            Coroutine = true;
            CaixaText.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pai"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(textDisplay);
            CaixaText.enabled = false;
        }
    }
    }
