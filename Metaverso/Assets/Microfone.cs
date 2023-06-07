using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.Unity;
using Fusion;


public class Microfone : NetworkBehaviour
{
    public GameObject speaker;
    public GameObject microfone;
    private AudioSource audioSource;

    private Recorder recorder1;

    private VoiceConnection voiceConnection;

    private bool isMuted = false;
   
    private void Start()
    {
        //audioSource = speaker.GetComponent<AudioSource>();
    }

    private void Update()
    {
        //voiceConnection.Client.OpChangeGroups();
    }

    public Recorder GetRecorder()
    {
        return recorder1;
    }

    public void ClickButton(Recorder recorder)
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            Debug.Log("mute on");
            recorder.TransmitEnabled = false;

            

        }
        else
        {
            Debug.Log("mute off");
            recorder.TransmitEnabled = true;
            
        }
    }
}
