using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerportaRH : MonoBehaviour
{
     private Animator myDoor = null;

     private bool openTrigger = false;
     private bool closeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PLayer"))
        {
            if (openTrigger)
            {
                myDoor.Play("anim_porta_RH", 0, 0.0f);
                gameObject.SetActive(false);
            }

            else if (closeTrigger)
            {
                myDoor.Play("anim_porta1_RH_fecha", 0, 0.0f);
                gameObject.SetActive(false);
            }
       
        } 
        
    }



}
