using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
namespace YoutubePlayer
{ 
    public class VideoControll : MonoBehaviour
    {
        public YoutubePlayer youtubePlayer;
        VideoPlayer videoPlayer;

        private void Awake()
        {
            videoPlayer = GetComponent<VideoPlayer>();
            videoPlayer.prepareCompleted += VideoPlayerPreparedCompleted;
        }
        public void VideoPlayerPreparedCompleted(VideoPlayer source)
        {
            
        }

        public async void Prepare()
        {
            print("carregando video..");
            try
            {
                await youtubePlayer.PrepareVideoAsync();
                print("video carregado");
                videoPlayer.Play();
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

        public void playVideo1()
        {
            videoPlayer.Stop();
            string ytUrl = "https://www.youtube.com/watch?v=aX5Vy04SkY8";
            videoPlayer.GetComponent<YoutubePlayer>().youtubeUrl = ytUrl;
            Prepare();
        }

        void OnDestroy()
        {
            videoPlayer.prepareCompleted -= VideoPlayerPreparedCompleted;
        }
    }   
}
