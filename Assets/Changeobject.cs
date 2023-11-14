using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changeobject : MonoBehaviour
{
    public GameObject rosca;
    public GameObject quadrado;
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.CompareTag("Rato"))
        {
            rosca.SetActive(true);
            quadrado.SetActive(false);
            anim.speed = 1.0f;
        }




    }
}
