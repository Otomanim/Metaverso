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
    public YoutubePlayer youtubePlayerRecepcao;
    public YoutubePlayer youtubePlayerAuditorio;
    public VideoPlayer videoPlayerRecepcao;
    public VideoPlayer videoPlayerAuditorio;
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
            videoPlayerRecepcao.url = "";
            youtubePlayerRecepcao.youtubeUrl = "https://www.youtube.com/watch?v=aX5Vy04SkY8&pp=ygUIZm91cnN5c10%3D";
            videoPlayerRecepcao = youtubePlayerRecepcao.GetComponent<VideoPlayer>();
            videoPlayerRecepcao.prepareCompleted += VideoPlayerPreparedCompleted;
        }

        void Start()
        {
            //youtubeVideoLinks = new List<string>();
            //addButton.onClick.AddListener(TaskOnClick);
        }

        void VideoPlayerPreparedCompleted(VideoPlayer source)
        {
            print(source.isPrepared);
            videoPlayerRecepcao.Play();
            canPlay = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                videoPlayerAuditorio.Play();
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                videoPlayerAuditorio.Pause();
            }
            
            if (Input.GetKeyDown(KeyCode.K))
            {
                videoPlayerAuditorioPrepare();
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                videoPlayerAuditorio.Stop();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                videoPlayerAuditorio.StepForward();
            }
        }
        public async void videoPlayerAuditorioPrepare()
        {
            print("carregando video..");

            try
            {
                await youtubePlayerAuditorio.PrepareVideoAsync();

                print("video carregado");
            }
            catch
            {
                print("ERROR video não carregado");
            }
        }

        private async void Prepare()
        {
            print("Carregando video");
            try
            {
                await youtubePlayerRecepcao.PrepareVideoAsync();
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
                videoPlayerRecepcao.Play();
               isPlaying = true;
            }

            else
            {
                videoPlayerRecepcao.Pause();
                isPlaying = false;
            }
        }

        public void Stop()
        {
            videoPlayerRecepcao.Stop();
        }

        public void playVideoWithURL(string link)
        {
            youtubePlayerRecepcao.youtubeUrl = link;
            Prepare();
        }

        private void OnDestroy()
        {
            videoPlayerRecepcao.prepareCompleted -= VideoPlayerPreparedCompleted;
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