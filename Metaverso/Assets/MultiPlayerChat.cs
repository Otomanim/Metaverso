using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fusion;
using System;

public class MultiPlayerChat : NetworkBehaviour
{
    private NetworkPlayer networkPlayer;

    public Text _message;
    public Text input;
    public TextMeshProUGUI usernameInput;
    public string username = "Default";

    private Text textLegacy;

    private void Start()
    {
        networkPlayer = new NetworkPlayer();
        username = networkPlayer.username;
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
