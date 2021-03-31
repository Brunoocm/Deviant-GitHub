using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{

    public static SoundEffectManager Instance;

    public AudioClip ArvoreCresce;
    public AudioClip ArvoreDiminui;
    public AudioClip Maquina;
    public AudioClip Madeira;
    public AudioClip Esmaga;


    private void Awake()
    {
        
        if (Instance != null)
        {
            Debug.LogError("Existem múltiplas instancias do script");
            
        }
        Instance = this;
    }

    public void MakeCrescer()
    {
        MakeSound(ArvoreCresce);
    }

    public void MakeDiminui()
    {
        MakeSound(ArvoreDiminui);
    }

    public void MakeMaquina()
    {
        MakeSound(Maquina);
    }

    public void MakeMadeira()
    {
        MakeSound(Madeira);
    }

    public void MakeEsmaga()
    {
        MakeSound(Esmaga);
    }



    private void MakeSound (AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }

}
