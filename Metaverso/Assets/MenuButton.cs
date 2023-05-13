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
        if (Input.GetKeyDown(KeyCode.B))
        {
            ClickButton();

        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("===== click ======");
        }
    }
    public void ClickButton()
    {
        painel = !painel;

        if (painel)
        {
            menu.SetActive(true);
            Debug.Log("======= active========");
        }
        else
        {
            menu.SetActive(false);
            Debug.Log("======== inative==========");
        }
    }
}
