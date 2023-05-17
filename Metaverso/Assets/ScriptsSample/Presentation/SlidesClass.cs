using UnityEngine;

public class SlidesClass : MonoBehaviour
{
    public Material[] materiais;
    public Renderer telaInicial;
    private int indiceMaterialAtual = 0;
    private int indiceMaterialAnterior = 0;
    private bool isPlayerInsideTrigger = false;
    public Camera fullScreen;
    private bool isFullScreenActive = false;

    private void Start()
    {
        if (telaInicial == null)
        {
            telaInicial = GetComponent<Renderer>();
        }

        AtualizarMaterial();
    }

    private void Update()
    {
        if (isPlayerInsideTrigger)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ToggleFullScreen();
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                TrocarProximoMaterial();
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                TrocarMaterialAnterior();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInsideTrigger = true;
            telaInicial.material = materiais[1];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInsideTrigger = false;
            telaInicial.material = materiais[0];
        }
    }

    private void ToggleFullScreen()
    {
        isFullScreenActive = !isFullScreenActive;
        fullScreen.gameObject.SetActive(isFullScreenActive);
    }

    public void TrocarProximoMaterial()
    {
        indiceMaterialAnterior = indiceMaterialAtual;
        indiceMaterialAtual = (indiceMaterialAtual + 1) % materiais.Length;

        AtualizarMaterial();
    }

    public void TrocarMaterialAnterior()
    {
        indiceMaterialAnterior = indiceMaterialAtual;
        indiceMaterialAtual = (indiceMaterialAtual - 1 + materiais.Length) % materiais.Length;

        AtualizarMaterial();
    }

    private void AtualizarMaterial()
    {
        if (telaInicial != null && materiais.Length > 0)
        {
            telaInicial.material = materiais[indiceMaterialAtual];
        }
    }
}
