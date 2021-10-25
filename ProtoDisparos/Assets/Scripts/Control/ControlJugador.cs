using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public Camera camaraPrimeraPersona;
    public float rapidezDesplazamiento = 10.0f;
    public float hitDistance = 10.0f;
    private AudioSource source;
    public AudioClip gunShot;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        source = gameObject.AddComponent<AudioSource>();
        source.clip = gunShot = Resources.Load<AudioClip>("effect_shot");
    }

    void Update()
    {
        float movimientoAdelanteAtras = Input.GetAxis("Vertical") * rapidezDesplazamiento;
        float movimientoCostados = Input.GetAxis("Horizontal") * rapidezDesplazamiento;

        movimientoAdelanteAtras *= Time.deltaTime;
        movimientoCostados *= Time.deltaTime;

        transform.Translate(movimientoCostados, 0, movimientoAdelanteAtras);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camaraPrimeraPersona.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            source.PlayOneShot(gunShot, 0.3f);

            if ((Physics.Raycast(ray, out hit) == true) && hit.distance < hitDistance)
            {
                Debug.Log("El rayo tocó al objeto: " + hit.collider.name);

                if (hit.collider.gameObject.name.Contains("Bot"))
                {
                    GameObject objetoTocado = hit.collider.gameObject;
                    ControlBot scriptObjetoTocado = (ControlBot)objetoTocado.GetComponentInParent((typeof(ControlBot)));

                    if (scriptObjetoTocado != null)
                    {
                        if (hit.collider.gameObject.name.Contains("Head"))
                        {
                            scriptObjetoTocado.headShot();
                        }
                        else
                        {
                            scriptObjetoTocado.recibirDaño();
                        }
                    }
                }
            }
        }


    }
}
