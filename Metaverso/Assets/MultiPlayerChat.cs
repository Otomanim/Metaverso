using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fusion;
using System;

public class MultiPlayerChat : NetworkBehaviour
{
    public Text _message;
    public Text input;
    TextMeshProUGUI usernameInput;
    public string username = "Default";
    string user; 

    private void Start()
    {
        user = PlayerPrefs.GetString("PlayerNickname");
        username = user;
        Debug.Log(user);

        //username = usernameInput.text;
        Debug.Log(username);

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
