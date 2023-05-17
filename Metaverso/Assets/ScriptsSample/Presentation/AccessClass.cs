using UnityEngine;
using UnityEngine.SceneManagement;

public class AccessClass : MonoBehaviour
{
    private bool collidedWithMonitor = false;
    private Renderer objectRenderer;

    public Material telaTreinamentoMaterial;
    public Material pretoMaterial;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();        
        ChangeMaterial(pretoMaterial);
    }

    private void OnTriggerEnter(Collider other)
    {
        collidedWithMonitor = true;
        ChangeMaterial(telaTreinamentoMaterial);
    }

    private void OnTriggerExit(Collider other)
    {
        collidedWithMonitor = false;
        ChangeMaterial(pretoMaterial);
    }

    private void Update()
    {
        if (collidedWithMonitor && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Class");
        }
    }

    private void ChangeMaterial(Material material)
    {
        objectRenderer.material = material;
    }
}
