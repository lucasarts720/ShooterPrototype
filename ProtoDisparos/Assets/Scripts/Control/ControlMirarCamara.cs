using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMirarCamara : MonoBehaviour
{
    Vector2 mouseMirar;
    Vector2 suavidadV;

    public float sensibilidad = 5.0f;
    public float suavizado = 2.0f;

    GameObject jugador;

    void Start()
    {
        jugador = this.transform.parent.gameObject;
    }

    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensibilidad * suavizado, sensibilidad * suavizado));

        suavidadV.x = Mathf.Lerp(suavidadV.x, md.x, 1f / suavizado);
        suavidadV.y = Mathf.Lerp(suavidadV.y, md.y, 1f / suavizado);

        mouseMirar += suavidadV;
        mouseMirar.y = Mathf.Clamp(mouseMirar.y, -90f, 90f);
        transform.localRotation = Quaternion.AngleAxis(-mouseMirar.y, Vector3.right);
        jugador.transform.localRotation = Quaternion.AngleAxis(mouseMirar.x, jugador.transform.up);
    }
}

