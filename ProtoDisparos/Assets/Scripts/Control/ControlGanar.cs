
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlGanar : MonoBehaviour
{
    public Text textBajas;
    public int cont;

    void Start()
    {
        cont = 0;
    }

    private void Update()
    {
        ContadorBajas();
    }

    private void ContadorBajas()
    {
        textBajas.text = "Enemigos Asesinados: " + cont.ToString();
        if (cont >= 5)
        {
            SceneManager.LoadScene("Ganar", LoadSceneMode.Single);
        }
    }
}