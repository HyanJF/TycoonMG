using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoorMove : MonoBehaviour
{ 
    public Animator laPuerta;
    private void OnTriggerEnter(Collider other)
    {
        laPuerta.Play("Abrir");
    }
    private void OnTriggerExit(Collider other)
    {
        laPuerta.Play("Cerrar");
    }
}
