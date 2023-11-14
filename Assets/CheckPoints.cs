using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoints : MonoBehaviour
{
    int pontos = 0;
    public TextMeshProUGUI textPontis;

    private void Start()
    {
        textPontis.text = "Pontos: 0";

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "pato")
        {
            Debug.Log(other.name);
            pontos = pontos + 1;
            textPontis.text = "Pontos: "+pontos.ToString();  
              
        }
     
        
    }

}
