using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;

public class SyncPlayerAudio : MonoBehaviour
{
    VideoPlayer video;
    public GameObject TV;
    NetworkCharacterControllerPrototypeCustom networkCharacterControllerPrototypeCustom;
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    private void Awake()
    {
        networkCharacterControllerPrototypeCustom = GetComponent<NetworkCharacterControllerPrototypeCustom>();
        video = VideoPlayer.FindAnyObjectByType<VideoPlayer>();
    }
    

    // Update is called once per frame
    void Update()
    {
        float _distance = Vector3.Distance(TV.transform.position, networkCharacterControllerPrototypeCustom.transform.position) * -1.0f + 10.0f;
        video.SetDirectAudioVolume(0, _distance / 20.0f);
        
    }

    public void SetTvVol(float vol)
    {
        audioMixer.SetFloat("Recepcao", vol);
        
    }
}
