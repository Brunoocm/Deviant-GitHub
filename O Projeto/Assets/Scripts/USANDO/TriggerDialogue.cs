using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDialogue : MonoBehaviour
{
    public Button ContinueButton;
    public Button yourButton;
    public GameObject continueB;
    public GameObject canvas;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            TaskOnClickContinue();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Pai"))
        {
            
            canvas.SetActive(true);
            TaskOnClick();

        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Pai"))
        {
            canvas.SetActive(false);
        }
    }

    void TaskOnClick()
    {
        yourButton.onClick.Invoke();
    }
    void TaskOnClickContinue()
    {
        ContinueButton.onClick.Invoke();
    }
}
