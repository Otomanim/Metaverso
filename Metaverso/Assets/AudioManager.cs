using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioMixer audioMixer;

    public Slider slider;
    
    private string audioZone; // A zona de áudio atual

    private float sliderVol;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        
    }

    private void Update()
    {

        //Debug.Log(slider.value);
    }

    public void SetAudioZone(string zoneTag)
    {
        
        audioZone = zoneTag;
        if (audioZone == "Auditorio")
        {
            audioMixer.SetFloat(audioZone, 0);
            Debug.Log("Auditorio");
        }

        if (audioZone == "Cafe")
        {
            audioMixer.SetFloat(audioZone, 0);
            Debug.Log("Cafe");
        }

        if (audioZone == "Jardim")
        {
            audioMixer.SetFloat(audioZone, 0);
            Debug.Log("Jardim");
        }

        if (audioZone == "Onboarding")
        {
            audioMixer.SetFloat(audioZone, 0);
            Debug.Log("Onboarding");
        }

        if (audioZone == "Recepcao")
        {
            audioMixer.SetFloat(audioZone, -10);
            Debug.Log("Recepcao");
        }

        if (audioZone == "Treinamento")
        {
            audioMixer.SetFloat(audioZone, 0);
            Debug.Log("Treinamento");
        }
        // Aqui você pode ajustar as configurações de áudio com base na zona atual, como volume, mixagem, etc.
    }

    public void ResetAudioZone()
    {
        audioMixer.SetFloat(audioZone, -80);
        audioZone = null;
        
        // Aqui você pode reverter as configurações de áudio para o estado padrão ou fazer outras ações necessárias.
    }

    public void VolumeSlider(float vol)
    {
        
        sliderVol = vol;
        audioMixer.SetFloat("Master", sliderVol);
    }
}
