using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuConfiguracoes : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume_master", volume);
    }

    public void setMuteMusica(bool musica)
    {
        if(musica)
        {
            audioMixer.SetFloat("volume_musica", 0f);
        }
        else
        {
            audioMixer.SetFloat("volume_musica", -80f);
        }
    }
    public void setMuteEfeitos(bool efeitos)
    {
        if (efeitos)
        {
            audioMixer.SetFloat("volume_efeitos", 0f);
        }
        else
        {
            audioMixer.SetFloat("volume_efeitos", -80f);
        }
    }
}
