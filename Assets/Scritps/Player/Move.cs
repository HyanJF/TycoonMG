using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //Variables publicas
    public Transform cameraAim;
    public float walkSpeed, runSpeed, rotationSpeed;
    public bool canMove;

    //Variables privadas
    private Vector3 vectorMovement;
    private float speed;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        speed = walkSpeed;
        vectorMovement = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Walk();
            Run();
            AlignPlayer();
        }
        Gravity();
    }

    // Funcion para caminar
    void Walk()
    {
        //Conseguir los imput
        vectorMovement.x = Input.GetAxis("Horizontal");
        vectorMovement.z = Input.GetAxis("Vertical");

        // Normalizamos el movimiento
        vectorMovement = vectorMovement.normalized;

        // Movernos en Direccion a la camara.

        vectorMovement = cameraAim.TransformDirection(vectorMovement);

        // Movemos al player
        characterController.Move(vectorMovement * speed * Time.deltaTime);

    }

    // Funcion para correr
    void Run()
    {
        // Si presionamos el boton para correr modificaciones la velocidad
        if (Input.GetAxis("Run") > 0f)
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }

    // Funcion provicional de gravedad
    void Gravity()
    {
        characterController.Move(new Vector3(0f, -4f * Time.deltaTime, 0f));
    }
    // Alinear con el player
    void AlignPlayer()
    {
        // Si nos estamos moviendo alineamos la rotacion
        if (characterController.velocity.magnitude > 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(vectorMovement), rotationSpeed * Time.deltaTime);
        }
    }
}