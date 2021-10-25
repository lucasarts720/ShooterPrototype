using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatX : MonoBehaviour
{

    bool Moverme = false;
    public int rapidez = 5;
    public int XMinimo;
    public int XMaximo;

    void Update()
    {
        if (transform.position.x >= XMaximo)
        {
            Moverme = true;
        }
        if (transform.position.x <= XMinimo)
        {
            Moverme = false;
        }

        if (Moverme)
        {
            Bajar();
        }
        else
        {
            Subir();
        }

    }

    void Subir()
    {
        transform.position += transform.right * rapidez * Time.deltaTime;
    }

    void Bajar()
    {
        transform.position -= transform.right * rapidez * Time.deltaTime;
    }
}

