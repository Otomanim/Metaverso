using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualIntegracao : MonoBehaviour
{
    public GameObject manualIntegracao;
    private bool manual = false;

    private void Update()
    {


    }
    public void ClickButton()
    {
        manual = !manual;

        if (manual)
        {
            manualIntegracao.SetActive(true);
            Debug.Log("======= active Menu ========");
        }
        else
        {
            manualIntegracao.SetActive(false);
            Debug.Log("======== inative Menu ==========");
        }
    }
}
