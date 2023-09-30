using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Variables publicas
    public float sensibility;
    public Transform cameraJointY, targetObject;
    public bool canRotate;
                        
    //Variables privadas
    private float xRotation, yRotation;

    // Start is called before the first frame update
    void Start()
    {
        //inicializar variables
        canRotate = true;

    }

    // Update is called once per frame
    void Update()
    {
        // Si podemos rotar
        if(canRotate)
        {
            Rotate();
        }

        // Seguimos al objetivo
        FollowTarget();
    }

    //Funcion de rotacion de camara
    void Rotate()
    {
        //Conseguir inputs de mause
        xRotation += Input.GetAxis("Mouse X") * Time.deltaTime * sensibility;
        yRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * sensibility;

        //Limitacion en y
        yRotation = Mathf.Clamp(yRotation, -65, 65);

        //Rotamos los componentes X y Y
        transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
        cameraJointY.transform.localRotation = Quaternion.Euler(-yRotation, 0f, 0f);
    }   
    
    //Funcion para seguir al objetivo
    void FollowTarget()
    {
        transform.position = targetObject.position;
    }
}