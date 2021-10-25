using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSalto : MonoBehaviour
{

    public float magnitudSalto;
    public Rigidbody rb;
    public Transform GroundCheckTransform;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Physics.OverlapSphere(GroundCheckTransform.position, 0.5f).Length <= 1)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * magnitudSalto, ForceMode.Impulse);
        }
    }
}
