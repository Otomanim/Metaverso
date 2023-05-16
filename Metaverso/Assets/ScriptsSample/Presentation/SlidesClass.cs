using UnityEngine;
using UnityEngine.SceneManagement;

public class SlidesClass : MonoBehaviour
{
    public Material[] materiais;
    public Renderer telaInicial;
    private int indiceMaterialAtual = 0;
    private int indiceMaterialAnterior = 0;

    private void Start()
    {
        if (telaInicial == null)
        {
            telaInicial = GetComponent<Renderer>();
        }

        AtualizarMaterial();
    }

    public void TrocarProximoMaterial()
    {
        indiceMaterialAnterior = indiceMaterialAtual;
        indiceMaterialAtual++;
        if (indiceMaterialAtual >= materiais.Length)
        {
            indiceMaterialAtual = 0;
        }

        AtualizarMaterial();
    }

    public void TrocarMaterialAnterior()
    {
        indiceMaterialAnterior = indiceMaterialAtual;
        indiceMaterialAtual--;
        if (indiceMaterialAtual < 0)
        {
            indiceMaterialAtual = materiais.Length - 1;
        }

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
