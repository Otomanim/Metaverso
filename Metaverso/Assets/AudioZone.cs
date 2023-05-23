using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioZone : MonoBehaviour
{

    public string zoneTag; // A tag da zona de áudio

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica se o objeto que entrou na zona é o jogador
        {

            Debug.Log("entrou");
            AudioManager.Instance.SetAudioZone(zoneTag); // Define a zona de áudio atual no AudioManager
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica se o objeto que saiu da zona é o jogador
        {
            Debug.Log("saiu");
            AudioManager.Instance.ResetAudioZone(); // Reseta a zona de áudio atual no AudioManager
        }
    }
}


