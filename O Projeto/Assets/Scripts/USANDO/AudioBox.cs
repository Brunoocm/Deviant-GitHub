using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBox : MonoBehaviour
{
    Rigidbody2D rb;

    private BoxPush anotherScript;

    public AudioClip[] clipsBox;


    public float minPitch = .95f;
    public float maxPitch = 1.05f;
    public float timer;

    void Awake()
    {
        anotherScript = GetComponent<BoxPush>();
        rb = anotherScript.GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (rb.velocity.x > 0 && rb.velocity.y == 0 || rb.velocity.x < 0 && rb.velocity.y == 0)
        {
            PlaySoundBox();
        }
    }

    void PlaySoundBox()
    {
        //Box
        int randomClip = Random.Range(0, clipsBox.Length);
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = clipsBox[randomClip];
        source.pitch = Random.Range(minPitch, maxPitch);
        source.Play();
        Destroy(source, clipsBox[randomClip].length);
        //BoxEnd
    }
}
