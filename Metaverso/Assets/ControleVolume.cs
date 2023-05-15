using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleVolume : MonoBehaviour
{
    public GameObject sliderVolume;

    private bool slider = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
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

        slider = !slider;

        if (slider)
        {
            sliderVolume.SetActive(true);
            Debug.Log("======= active========");
        }
        else
        {
            sliderVolume.SetActive(false);
            Debug.Log("======== inative==========");
        }
    }
}
