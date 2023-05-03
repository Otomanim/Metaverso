using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetUserName : MonoBehaviour
{
    private GameManager gameManager;
    public Text textName;
    void Start()
    {
        textName.text = PlayerPrefs.GetString("user_name");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
