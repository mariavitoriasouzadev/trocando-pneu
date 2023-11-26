using UnityEngine;
using System.Collections;

public class Desparafusar : MonoBehaviour
{
    public GameObject bolt;
    public string botaoNome;
    public LayerMask camadaParafuso;

    private Coroutine desparafusarCoroutine;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, camadaParafuso)) {
                if (hit.collider.gameObject.name == botaoNome){
                    desparafusarCoroutine = StartCoroutine(desparafusar());
                }
            }
        }
    }

    IEnumerator desparafusar(){
        float posInicial = bolt.transform.position.x;
        float posFinal = posInicial - 50f;

        float rotInicial = bolt.transform.rotation.z;
        float rotFinal = rotInicial + 50f;

        while (bolt.transform.position.y > posFinal){
            float novaPos = Mathf.MoveTowards(bolt.transform.position.x, posFinal, Time.deltaTime * 50f);
            float novaRot = Mathf.MoveTowards(bolt.transform.rotation.z, rotFinal, Time.deltaTime * 50f);
            bolt.transform.position = new Vector3(
                novaPos,
                bolt.transform.position.y,
                bolt.transform.position.z
            );

             

            // Verifica a proximidade da posição final
            if (Mathf.Approximately(bolt.transform.position.x, posFinal))
            {
                Rigidbody rb = bolt.GetComponent<Rigidbody>();
                rb = bolt.AddComponent<Rigidbody>();
                rb.mass = 500.0f;

                BoxCollider boxCollider = bolt.AddComponent<BoxCollider>();

                StopCoroutine(desparafusarCoroutine);
            }

            yield return null;
        }
    }
}
