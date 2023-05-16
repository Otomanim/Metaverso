using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using static UnityEngine.EventSystems.EventTrigger;

public class VideoController : MonoBehaviour
{
    [HideInInspector]
    public VideoPlayer videoPlayer;
    AudioSource audioSource;
    //public GameObject jogador;
    public GameObject centro;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        //float _distance = Vector3.Distance(centro.transform.position, jogador.transform.position) * -1.0f + 10.0f;

        //float newVolume = Mathf.Max(Mathf.Min(1.0f, _distance),0.01f);


        //videoPlayer.SetDirectAudioVolume(0, _distance / 20.0f);
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        videoPlayer.Play();
        videoPlayer.SetDirectAudioVolume(0, 1.0f);
    }

    private void OnTriggerExit(Collider other)
    {
        videoPlayer.Pause();
    }
}
