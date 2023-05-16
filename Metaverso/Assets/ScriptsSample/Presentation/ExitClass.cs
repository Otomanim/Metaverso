using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitClass : MonoBehaviour
{
    public void SairDaSala() 
    {        
        SceneManager.LoadScene("SampleScene");
    }
}
