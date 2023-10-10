using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    // Variables publicas
    public float radius;
    public LayerMask detectedLayers;

    // Variables privadas
    private bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        CheckGround();
    }

    void CheckGround()
    {
        isGrounded = Physics.CheckSphere(transform.position, radius, detectedLayers);
    }

    // Funcion para devolver el valor de isGrounded
    public bool GetIsGrounded()
    {
        return isGrounded;

    }
}
