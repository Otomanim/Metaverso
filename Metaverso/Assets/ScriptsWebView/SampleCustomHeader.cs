using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCustomHeader : MonoBehaviour
{
    const float Button_Height = 50.0f;
    const string Custom_header_Key_Name = "custom_timestamp";

    WebViewObject _webviewObject;

    void OnGUI()
    {
        float h = Screen.height;
        if (GUI.Button(new Rect(.0f, h - Button_Height, Screen.width, Button_Height), "check for request header"))
        {
            this._webviewObject = GameObject.Find("WebViewObject").GetComponent<WebViewObject>();
            this._webviewObject.LoadURL("http://httpbin.org/headers");
        }
        h -= Button_Height;

        if (GUI.Button(new Rect(.0f, h - Button_Height, Screen.width, Button_Height), "add custom header"))
        {
            this._webviewObject = GameObject.Find("WebViewObject").GetComponent<WebViewObject>();
            this._webviewObject.AddCustomHeader(Custom_header_Key_Name, System.DateTime.Now.ToString());
        }
        h -= Button_Height;

        if (GUI.Button(new Rect(.0f, h - Button_Height, Screen.width, Button_Height), "get custom header"))
        {
            this._webviewObject = GameObject.Find("WebViewObject").GetComponent<WebViewObject>();
            Debug.Log("custom_timestamp is " + this._webviewObject.GetCustomHeaderValue(Custom_header_Key_Name));
        }
        h -= Button_Height;

        if (GUI.Button(new Rect(.0f, h - Button_Height, Screen.width, Button_Height), "remove custom header"))
        {
            this._webviewObject = GameObject.Find("WebViewObject").GetComponent<WebViewObject>();
            this._webviewObject.RemoveCustomHeader(Custom_header_Key_Name);
        }
        h -= Button_Height;

        if (GUI.Button(new Rect(.0f, h - Button_Height, Screen.width, Button_Height), "clear custom header"))
        {
            this._webviewObject = GameObject.Find("WebViewObject").GetComponent<WebViewObject>();
            this._webviewObject.ClearCustomHeader();
        }
        h -= Button_Height;
    }
}
