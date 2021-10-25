using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatZ : MonoBehaviour
{

    bool Moverme = false;
    public int rapidez = 5;
    public int ZMinimo;
    public int ZMaximo;

    void Update()
    {
        if (transform.position.z >= ZMaximo)
        {
            Moverme = true;
        }
        if (transform.position.z <= ZMinimo)
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
        transform.position += transform.forward * rapidez * Time.deltaTime;
    }

    void Bajar()
    {
        transform.position -= transform.forward * rapidez * Time.deltaTime;
    }
}


