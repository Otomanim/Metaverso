using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChat : MonoBehaviour
{
    public GameObject chatPanel;

    private bool painelChat = false;

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
}
