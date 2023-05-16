using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleVolume : MonoBehaviour
{
    public GameObject sliderVolume;

    private bool slider = false;

    private void Update()
    {
        
        
    }
    public void ClickButton()
    {

        slider = !slider;

        if (slider)
        {
            sliderVolume.SetActive(true);
            Debug.Log("======= active Slider ========");
        }
        else
        {
            sliderVolume.SetActive(false);
            Debug.Log("======== inative Slider ==========");
        }
    }
}
