using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microfone : MonoBehaviour
{
    public GameObject speaker;
    public GameObject microfone;
    private AudioSource audioSource;
    private bool isMuted = false;

    private void Start()
    {
        //audioSource = speaker.GetComponent<AudioSource>();
    }

    private void Update()
    {
        
    }

    //public void ClickButton()
    //{
    //    isMuted = !isMuted;
    //    if (isMuted)
    //    {
    //        Debug.Log("mute on");
    //        audioSource.mute = true;
    //        //microfone.GetComponents<IMa>

    //    }
    //    else
    //    {
    //        Debug.Log("mute off");
    //        audioSource.mute = false;
    //        //audioSource.clip = Microphone.Start(null, true, 10, AudioSettings.outputSampleRate);
    //        //audioSource.loop = true;
    //        //while (!(Microphone.GetPosition(null) > 0)) { }
    //        //audioSource.Play();
    //    }
    //}
}
