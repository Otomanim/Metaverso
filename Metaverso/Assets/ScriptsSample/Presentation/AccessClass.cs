using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccessClass : MonoBehaviour
{
    void Update()
    {
        
    }

    private void OnTriggerEnter() {
        if(Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene("Class");
            Debug.Log("Pressionou Enter");
        }
    }
}
