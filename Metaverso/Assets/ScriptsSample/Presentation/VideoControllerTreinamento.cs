using UnityEngine; 
using UnityEngine.Video;

public class VideoControllerTreinamento : MonoBehaviour
{
    public VideoPlayer videoPlayer; 
    public GameObject jogador;
    public GameObject centro;

    void Awake(){
        videoPlayer = GetComponent<VideoPlayer>(); 
        videoPlayer.Stop();
    }

    void Update()
    {
        float _distance = Vector3.Distance (centro.transform.position, jogador.transform.position);
        float volume = Mathf.Clamp(1.0f - _distance/2.5f, 0.0f, 1.0f);
        videoPlayer.SetDirectAudioVolume(0, volume);
    }

    void OnTriggerEnter(Collider outroObjeto)
    {
        videoPlayer.Play();
        videoPlayer.SetDirectAudioVolume(0, 1.0f);
    }

    void OnTriggerExit(Collider outroObjeto)
    {
        videoPlayer.SetDirectAudioVolume(0, 0.0f);
    }
}
