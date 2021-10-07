using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleAudio : MonoBehaviour
{
    [SerializeField] private Som[] sons;

    public static ControleAudio instancia;

    // Start is called before the first frame update
    void Awake()
    {
        if(instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }


        foreach (Som som in sons)
        {
            som.source = gameObject.AddComponent<AudioSource>();
            som.source.clip = som.clip;
            som.source.volume = som.volume;
            som.source.pitch = som.pitch;
            som.source.loop = som.loop;
            som.source.outputAudioMixerGroup = som.grupo;

        }
    }

    public void Tocar(string nome)
    {
        Som s = Array.Find(sons, som => som.nome == nome);
        if (s != null)
            s.source.Play();
    }

    public void Parar(string nome)
    {
        Som s = Array.Find(sons, som => som.nome == nome);
        if (s != null)
            s.source.Stop();
    }
}
