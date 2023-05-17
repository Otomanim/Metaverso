using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManual : MonoBehaviour
{
    public GameObject webView;

    private WebView Url;
    private bool manual = false;

    private void Update()
    {

    }
    //funcao de habilitar e desabilitar o chat no canvas
    public void ClickButtonManual()
    {
        manual = !manual;

        if (manual)
        {
            
            //string url = "https://trello.com/b/zmGOKH3K/manual-de-integra%C3%A7%C3%A3o";
            //url = Url.ToString();
            webView.SetActive(true);
            Debug.Log("======= active Chat ========");
        }
        else
        {
            webView.SetActive(false);
            Debug.Log("======== inative Chat ==========");
        }
    }
}
