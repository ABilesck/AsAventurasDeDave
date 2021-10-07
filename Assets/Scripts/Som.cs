using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Som
{
    public string nome;

    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    public bool loop;
    public AudioMixerGroup grupo;

    [HideInInspector] public AudioSource source;
}
