using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text textName;
    public InputField inputText;
    void Start()
    {
        textName.text = PlayerPrefs.GetString("user_name");
    }

    public void GetText() {
        textName.text = inputText.text;
        PlayerPrefs.SetString("user_name", textName.text);
        PlayerPrefs.Save();

        textName.gameObject.SetActive(true);
    }
}
