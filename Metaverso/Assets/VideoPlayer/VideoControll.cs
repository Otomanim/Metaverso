using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

using UnityEngine.Video;




namespace YoutubePlayer

{

    // https://www.youtube.com/watch?v=aX5Vy04SkY8&pp=ygUIZm91cnN5c10%3D

    public class VideoControll : MonoBehaviour

    {
    //public GameObject player;
    public YoutubePlayer youtubePlayer;
    public VideoPlayer videoPlayer;
    public KeyCode fullScreenKey = KeyCode.G;
    //private bool isFullScreenNotActive = true;
    public InputField searchBar;
    public Button addButton;
    //private List<string> youtubeVideoLinks;
    //private int videoCount = 0;
    private bool canPlay = false;
    private bool isPlaying = true;


        private void Awake()
        {
            videoPlayer.url = "";
            youtubePlayer.youtubeUrl = "https://www.youtube.com/watch?v=aX5Vy04SkY8&pp=ygUIZm91cnN5c10%3D";
            videoPlayer = youtubePlayer.GetComponent<VideoPlayer>();
            videoPlayer.prepareCompleted += VideoPlayerPreparedCompleted;
        }

        void Start()

        {
            //youtubeVideoLinks = new List<string>();
            //addButton.onClick.AddListener(TaskOnClick);
        }

   




        void VideoPlayerPreparedCompleted(VideoPlayer source)

        {

            print(source.isPrepared);

            videoPlayer.Play();

            canPlay = true;

        }




        private async void Prepare()

        {

            print("Carregando video");

            try
            {

                await youtubePlayer.PrepareVideoAsync();

            }
            catch

            {

                print("ERRO");

            }

        }

        public void Play()
        {

            if (isPlaying == false)

            {

                videoPlayer.Play();

                isPlaying = true;

            }



            else

            {

                videoPlayer.Pause();

                isPlaying = false;

            }

        }

        public void Stop()
        {
            videoPlayer.Stop();
        }

        public void playVideoWithURL(string link)
        {
            youtubePlayer.youtubeUrl = link;
            Prepare();
        }

        private void OnDestroy()
        {
            videoPlayer.prepareCompleted -= VideoPlayerPreparedCompleted;
        }

        public bool getIsPlaying()
        {
            return isPlaying;
        }

        public bool getCanPlay()
        {
            return canPlay;
        }

    }







}