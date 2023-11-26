using UnityEngine;

public class BotaoDestaque : MonoBehaviour
{
    public string botaoNome = "Key_1"; // Nome do objeto que funciona como bot�o
    public Color corNormal; // Cor normal do bot�o
    public Color corDestaque = Color.green; // Cor quando o objeto � destacado
    public LayerMask camadaBotao; // Camada do bot�o

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
                return; // Retorna para evitar a restaura��o da cor normal neste frame
            }
        }

        // Se n�o estiver em destaque, restaura a cor normal
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
        // Restaura a cor normal do bot�o
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = corNormal;
    }
}
