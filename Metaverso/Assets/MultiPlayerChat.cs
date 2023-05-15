using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fusion;

public class MultiPlayerChat : NetworkBehaviour
{
    public Text _message;
    public Text input;
    public TextMeshProUGUI usernameInput;
    public string username = "Default";
    
    public GameObject chatPanel;
    
    private bool painelChat = false;

    private void Start()
    {
        username = usernameInput.text;
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ClickButtonChat();

        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("===== click ======");
        }
    }
    //funcao de habilitar e desabilitar o chat no canvas
    public void ClickButtonChat()
    {
        painelChat = !painelChat;

        if (painelChat)
        {
            chatPanel.SetActive(true);
            Debug.Log("======= active========");
        }
        else
        {
            chatPanel.SetActive(false);
            Debug.Log("======== inative==========");
        }
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
