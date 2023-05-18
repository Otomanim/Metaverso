using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

namespace YoutubePlayer
{
    public class VideoControl : MonoBehaviour
    {
        public YoutubePlayer youtubePlayer;
        VideoPlayer videoPlayer;

        private void Awake()
        {
            videoPlayer = youtubePlayer.GetComponent<VideoPlayer>();
            videoPlayer.prepareCompleted += VideoPlayerPreparedCompleted;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                PlayVideo();
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                PauseVideo();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                ResetVideo();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                Prepare();
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                StopVideo();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                ForwardVideo();
            }
        }

        void VideoPlayerPreparedCompleted(VideoPlayer source)
        {

        }

        public async void Prepare()
        {
            print("carregando video..");

            try
            {
                await youtubePlayer.PrepareVideoAsync();

                print("video carregado");
            }
            catch
            {
                print("ERROR video não carregado");
            }
        }

        public void PlayVideo()
        {
            videoPlayer.Play();
        }
        public void PauseVideo()
        {
            videoPlayer.Pause();
        }
        public void ResetVideo()
        {
            videoPlayer.Stop();
            videoPlayer.Play();
        }
        public void StopVideo()
        {
            videoPlayer.Stop();
        }
        public void ForwardVideo()
        {
            videoPlayer.StepForward();
        }


        void OnDestroy()
        {
            videoPlayer.prepareCompleted -= VideoPlayerPreparedCompleted;
        }


    }

}


