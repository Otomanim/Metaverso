using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fusion;
using System;

public class MultiPlayerChat : NetworkBehaviour
{
    public TextMeshProUGUI _message;
    public TMP_InputField input;
    TextMeshProUGUI usernameInput;
    public string username = "Default";

    private void Start()
    {

        username = PlayerPrefs.GetString("user_name");
        
        //username = usernameInput.text;
        Debug.Log(username+"============");

    }

    public void CallMessageRPC()
    {
        string message = input.text;
        RPC_SendMessage(username, message);
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void RPC_SendMessage(string username, string message, RpcInfo rpcInfo = default)
    {

        _message.text += $"{username}: {message}\n";
    }
}
