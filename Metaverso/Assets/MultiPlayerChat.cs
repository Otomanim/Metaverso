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
    public TextMeshProUGUI input;
    public TextMeshProUGUI usernameInput;
    //public string username = "Default";

    public NetworkString<_16> username { get; set; }


    private void Start()
    {
        username = usernameInput.text;
    }

    public void CallMessageRPC()
    {
        string message = input.text;
        RPC_SendMessage(username, message);
    }

    private void RPC_SendMessage(NetworkString<_16> username, string message)
    {
        throw new NotImplementedException();
    }

    [Rpc(RpcSources.All, RpcTargets.All)]

    public void RPC_SendMessage(string username, string message, RpcInfo rpcInfo = default)
    {

        _message.text += $"{username}: {message}\n";
    }
}
