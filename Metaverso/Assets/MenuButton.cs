using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{

    public GameObject menu;
    private bool painel = false;

    private void Update()
    {
        
        
    }
    public void ClickButton()
    {
        painel = !painel;

        if (painel)
        {
            menu.SetActive(true);
            Debug.Log("======= active Menu ========");
        }
        else
        {
            menu.SetActive(false);
            Debug.Log("======== inative Menu ==========");
        }
    }
}
