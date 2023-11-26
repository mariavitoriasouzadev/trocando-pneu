using UnityEngine;
using System.Collections;

public class ElevadorController : MonoBehaviour
{
    public GameObject lifterAndCar; // Refer�ncia ao objeto que cont�m o elevador e o carro
    public string botaoNome = "Key_1"; // Nome do objeto que funciona como bot�o
    public float alturaMaxima = 50f; // Altura m�xima que o elevador pode atingir
    public float velocidadeElevacao = 50f; // Velocidade de eleva��o
    public LayerMask camadaBotao; // Camada do bot�o

    private bool elevadorLevantado = false;
    private Coroutine elevacaoCoroutine;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Verifica se o bot�o esquerdo do mouse foi pressionado
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Modificamos Physics.Raycast para incluir a camada desejada
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, camadaBotao))
            {
                if (!elevadorLevantado)
                {
                    elevacaoCoroutine = StartCoroutine(LevantarElevador());
                }
                else
                {
                    elevacaoCoroutine = StartCoroutine(AbaixarElevador());
                }
            }
        }
    }

    IEnumerator LevantarElevador()
{
    float alturaInicial = lifterAndCar.transform.position.y;
    float alturaFinal = alturaInicial + alturaMaxima;
    elevadorLevantado = true;

    while (lifterAndCar.transform.position.y < alturaFinal)
    {
        float novaAltura = Mathf.MoveTowards(lifterAndCar.transform.position.y, alturaFinal, Time.deltaTime * velocidadeElevacao);
        lifterAndCar.transform.position = new Vector3(
            lifterAndCar.transform.position.x,
            novaAltura,
            lifterAndCar.transform.position.z
        );

        // Verifica a proximidade da posi��o final
        if (Mathf.Approximately(lifterAndCar.transform.position.y, alturaFinal))
        {
            StopCoroutine(elevacaoCoroutine);
        }

        yield return null;
    }
}

IEnumerator AbaixarElevador()
{
    float alturaInicial = lifterAndCar.transform.position.y;
    float alturaFinal = alturaInicial - alturaMaxima;
    elevadorLevantado = false;

    while (lifterAndCar.transform.position.y > alturaFinal)
    {
        float novaAltura = Mathf.MoveTowards(lifterAndCar.transform.position.y, alturaFinal, Time.deltaTime * velocidadeElevacao);
        lifterAndCar.transform.position = new Vector3(
            lifterAndCar.transform.position.x,
            novaAltura,
            lifterAndCar.transform.position.z
        );

        // Verifica a proximidade da posi��o final
        if (Mathf.Approximately(lifterAndCar.transform.position.y, alturaFinal))
        {
            StopCoroutine(elevacaoCoroutine);
        }

        yield return null;
    }
}

}