using System.Collections;
using System.Collections.Generic;
//using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using Fusion;
using UnityEngine.Networking;
using Unity.VisualScripting;

public class AgendaWeb : MonoBehaviour
{
    public GameObject gameObject;
    public Text status;
    WebViewObject webViewObject;


    private bool manual = false;
    public GameObject webView;


    private string Url = "https://workspace.google.com/products/calendar/?hl=pt-BR";

    public void TappedAgenda()
    {
        manual = !manual;

        if (manual)
        {
            webView.SetActive(true);
            Debug.Log("======= active Agenda ========");
        }
        else
        {
            webView.SetActive(false);
            Debug.Log("======== inative Agenda ==========");
        }
    }



    IEnumerator Start()
    {
        webViewObject = gameObject.AddComponent<WebViewObject>();


        if (gameObject != isActiveAndEnabled)
        {
            Debug.Log("======== desligado ========");
        }
        else
        {
            webViewObject.Init(
                cb: (msg) =>
                {
                    Debug.Log(string.Format("CallFromJS[{0}]", msg));
                    status.text = msg;
                    status.GetComponent<Animation>().Play();
                },
                err: (msg) =>
                {
                    Debug.Log(string.Format("CallOnError[{0}]", msg));
                    status.text = msg;
                    status.GetComponent<Animation>().Play();
                },
                httpErr: (msg) =>
                {
                    Debug.Log(string.Format("CallOnHttpError[{0}]", msg));
                    status.text = msg;
                    status.GetComponent<Animation>().Play();
                },
                started: (msg) =>
                {
                    Debug.Log(string.Format("CallOnStarted[{0}]", msg));
                },
                hooked: (msg) =>
                {
                    Debug.Log(string.Format("CallOnHooked[{0}]", msg));
                },
                cookies: (msg) =>
                {
                    Debug.Log(string.Format("CallOnCookies[{0}]", msg));
                },
                ld: (msg) =>
                {
                    Debug.Log(string.Format("CallOnLoaded[{0}]", msg));
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS
                    // NOTE: the following js definition is required only for UIWebView; if
                    // enabledWKWebView is true and runtime has WKWebView, Unity.call is defined
                    // directly by the native plugin.
#if true
                    var js = @"
                    if (!(window.webkit && window.webkit.messageHandlers)) {
                        window.Unity = {
                            call: function(msg) {
                                window.location = 'unity:' + msg;
                            }
                        };
                    }
                ";
#else
                // NOTE: depending on the situation, you might prefer this 'iframe' approach.
                // cf. https://github.com/gree/unity-webview/issues/189
                var js = @"
                    if (!(window.webkit && window.webkit.messageHandlers)) {
                        window.Unity = {
                            call: function(msg) {
                                var iframe = document.createElement('IFRAME');
                                iframe.setAttribute('src', 'unity:' + msg);
                                document.documentElement.appendChild(iframe);
                                iframe.parentNode.removeChild(iframe);
                                iframe = null;
                            }
                        };
                    }
                ";
#endif
#elif UNITY_WEBPLAYER || UNITY_WEBGL
                var js = @"
                    window.Unity = {
                        call:function(msg) {
                            parent.unityWebView.sendMessage('WebViewObject', msg);
                        }
                    };
                ";
#else
                var js = "";
#endif
                    webViewObject.EvaluateJS(js + @"Unity.call('ua=' + navigator.userAgent)");
                }
                //transparent: false,
                //zoom: true,
                //ua: "custom user agent string",
                //radius: 0,  // rounded corner radius in pixel
                //// android
                //androidForceDarkMode: 0,  // 0: follow system setting, 1: force dark off, 2: force dark on
                //// ios
                //enableWKWebView: true,
                //wkContentMode: 0,  // 0: recommended, 1: mobile, 2: desktop
                //wkAllowsLinkPreview: true,
                //// editor
                //separated: false

                );

            //webViewObject.bitmapRefreshCycle = 1;
            webViewObject.LoadURL(Url);
            webViewObject.SetMargins(0, 200, 0, 0);
            webViewObject.SetVisibility(true);


            Debug.Log("=====Loading video=======");

#if !UNITY_WEBPLAYER && !UNITY_WEBGL
            if (Url.StartsWith("http"))
            {
                webViewObject.LoadURL(Url.Replace(" ", "%20"));
            }
            else
            {
                var exts = new string[]{
                ".jpg",
                ".js",
                ".html"  // should be last
            };
                foreach (var ext in exts)
                {
                    var url = Url.Replace(".html", ext);
                    var src = System.IO.Path.Combine(Application.streamingAssetsPath, url);
                    var dst = System.IO.Path.Combine(Application.temporaryCachePath, url);
                    byte[] result = null;
                    if (src.Contains("://"))
                    {  // for Android
#if UNITY_2018_4_OR_NEWER
                        // NOTE: a more complete code that utilizes UnityWebRequest can be found in https://github.com/gree/unity-webview/commit/2a07e82f760a8495aa3a77a23453f384869caba7#diff-4379160fa4c2a287f414c07eb10ee36d
                        var unityWebRequest = UnityWebRequest.Get(src);
                        yield return unityWebRequest.SendWebRequest();
                        result = unityWebRequest.downloadHandler.data;
#else
                    var www = new WWW(src);
                    yield return www;
                    result = www.bytes;
#endif
                    }
                    else
                    {
                        result = System.IO.File.ReadAllBytes(src);
                    }
                    System.IO.File.WriteAllBytes(dst, result);
                    if (ext == ".html")
                    {
                        webViewObject.LoadURL("file://" + dst.Replace(" ", "%20"));
                        break;
                    }
                }
            }
#else
        if (Url.StartsWith("http")) {
            webViewObject.LoadURL(Url.Replace(" ", "%20"));
        } else {
            webViewObject.LoadURL("StreamingAssets/" + Url.Replace(" ", "%20"));
        }
#endif

        }

        void OnGUI()
        {
            var x = 10;

            GUI.enabled = (webViewObject == null) ? false : webViewObject.CanGoBack();
            if (GUI.Button(new Rect(x, 10, 80, 80), "<"))
            {
                webViewObject?.GoBack();
            }
            GUI.enabled = true;
            x += 90;

            GUI.enabled = (webViewObject == null) ? false : webViewObject.CanGoForward();
            if (GUI.Button(new Rect(x, 10, 80, 80), ">"))
            {
                webViewObject?.GoForward();
            }
            GUI.enabled = true;
            x += 90;

            if (GUI.Button(new Rect(x, 10, 80, 80), "r"))
            {
                webViewObject?.Reload();
            }
            x += 90;

            GUI.TextField(new Rect(x, 10, 180, 80), "" + ((webViewObject == null) ? 0 : webViewObject.Progress()));
            x += 190;

            if (GUI.Button(new Rect(x, 10, 80, 80), "*"))
            {
                var g = GameObject.Find("WebViewObject");
                if (g != null)
                {
                    Destroy(g);
                }
                else
                {
                    StartCoroutine(Start());
                }
            }
            x += 90;

            if (GUI.Button(new Rect(x, 10, 80, 80), "c"))
            {
                webViewObject?.GetCookies(Url);
            }
            x += 90;

            if (GUI.Button(new Rect(x, 10, 80, 80), "x"))
            {
                webViewObject?.ClearCookies();
            }
            x += 90;

            if (GUI.Button(new Rect(x, 10, 80, 80), "D"))
            {
                webViewObject?.SetInteractionEnabled(false);
            }
            x += 90;

            if (GUI.Button(new Rect(x, 10, 80, 80), "E"))
            {
                webViewObject?.SetInteractionEnabled(true);
            }
            x += 90;
        }


        //webView = gameObject.AddComponent<WebViewObject>();
        //webView.Init();
        //webView.LoadURL(url);
        //webView.SetMargins(50, 100, 50, 50);
        //webView.SetVisibility(true);

        //gameObject.AddComponent<WebViewObject>();

        //statusText.text = "Loading video...";
    }




}


