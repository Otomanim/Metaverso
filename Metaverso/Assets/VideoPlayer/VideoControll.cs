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
        public YoutubePlayer recepcaoYoutube;
        public YoutubePlayer auditorioYoutube;

        public VideoPlayer recepcaoPlayer;
        public VideoPlayer auditorioPlayer;
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
            recepcaoPlayer.url = "";
            recepcaoYoutube.youtubeUrl = "https://www.youtube.com/watch?v=aX5Vy04SkY8&pp=ygUIZm91cnN5c10%3D";
            recepcaoPlayer = recepcaoYoutube.GetComponent<VideoPlayer>();
            recepcaoPlayer.prepareCompleted += VideoPlayerPreparedCompleted;
        }

        void Start()
        {
            //youtubeVideoLinks = new List<string>();
            //addButton.onClick.AddListener(TaskOnClick);
        }

        void VideoPlayerPreparedCompleted(VideoPlayer source)
        {
            print(source.isPrepared);
            recepcaoPlayer.Play();
            canPlay = true;
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                auditorioPlayer.Play();
            }
            //if (Input.GetKeyDown(KeyCode.O))
            //{
            //    PauseVideo();
            //}
            //if (Input.GetKeyDown(KeyCode.L))
            //{
            //    ResetVideo();
            //}
            if (Input.GetKeyDown(KeyCode.K))
            {
                PrepareAuditorio();
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                auditorioPlayer.Stop();
            }
            //if (Input.GetKeyDown(KeyCode.P))
            //{
            //    ForwardVideo();
            //}
        }

        private async void Prepare()
        {
            print("Carregando video");
            try
            {
                await recepcaoYoutube.PrepareVideoAsync();
            }
            catch
            {
                print("ERRO");
            }
        }

        private async void PrepareAuditorio()
        {
            print("Carregando video");
            try
            {
                await auditorioYoutube.PrepareVideoAsync();
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
                recepcaoPlayer.Play();
                isPlaying = true;
            }

            else
            {
                recepcaoPlayer.Pause();
                isPlaying = false;
            }
        }

        public void Stop()
        {
            recepcaoPlayer.Stop();
        }

        public void playVideoWithURL(string link)
        {
            recepcaoYoutube.youtubeUrl = link;
            Prepare();
        }

        private void OnDestroy()
        {
            recepcaoPlayer.prepareCompleted -= VideoPlayerPreparedCompleted;
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