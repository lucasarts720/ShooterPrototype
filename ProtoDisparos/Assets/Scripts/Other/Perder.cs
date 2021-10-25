using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Perder : MonoBehaviour
{
    public Text Cronometro;
    float tiempoRestante;
    public float valorCronometro;

    private void Start()
    {
        StartCoroutine(ComenzarCronometro(valorCronometro));
    }

    public IEnumerator ComenzarCronometro(float valorCronometro)
    {
        tiempoRestante = valorCronometro;
        while (tiempoRestante > 0)
        {
            Cronometro.text = "Restan " + tiempoRestante.ToString() + " segundos";
            yield return new WaitForSeconds(1.0f);
            tiempoRestante--;
            Debug.Log("Restan " + tiempoRestante + " segundos.");
        }

        if (tiempoRestante <=0)
        {
            SceneManager.LoadScene("Perder", LoadSceneMode.Single);
        }
    }
 

}
