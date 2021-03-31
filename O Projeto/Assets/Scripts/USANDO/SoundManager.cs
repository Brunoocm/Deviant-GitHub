using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //De onde sai o som
    [Header("SOM")]
    public Transform MainCamera;

    [Header("INIMIGO")]
    public AudioClip Taser;

    public void TaserFunction()
    {
        AudioSource.PlayClipAtPoint(Taser, new Vector3((int)MainCamera.transform.position.x, 0, -40));
    }
}
