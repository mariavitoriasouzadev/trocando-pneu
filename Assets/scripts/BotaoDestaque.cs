using UnityEngine;

public class BotaoDestaque : MonoBehaviour
{
    public string botaoNome = "Key_1"; // Nome do objeto que funciona como botão
    public Color corNormal; // Cor normal do botão
    public Color corDestaque = Color.green; // Cor quando o objeto é destacado
    public LayerMask camadaBotao; // Camada do botão

    void Start()
    {
        // Salva a cor normal ao iniciar o script
        Renderer rend = GetComponent<Renderer>();
        corNormal = rend.material.color;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, camadaBotao))
        {
            if (hit.collider.gameObject.name == botaoNome)
            {
                DestacarBotao();
                return; // Retorna para evitar a restauração da cor normal neste frame
            }
        }

        // Se não estiver em destaque, restaura a cor normal
        RestaurarCorNormal();
    }

    void DestacarBotao()
    {
        // Troca a cor do material do objeto para a cor de destaque
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = corDestaque;
    }

    void RestaurarCorNormal()
    {
        // Restaura a cor normal do botão
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = corNormal;
    }
}
