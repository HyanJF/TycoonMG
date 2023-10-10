using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //Variables publicas
    public Transform cameraAim;
    public float walkSpeed, runSpeed, rotationSpeed, jumpForce;
    public bool canMove;
    public GroundDetector groundDetector;

    //Variables privadas
    private Vector3 vectorMovement, verticalForce;
    private float speed;
    private bool isGrounded;
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
            Jump();
        }
        Gravity();
        CheckGround();
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

    void Jump()
    {
        // Si estamos tocando el suelo y precionamos espacio
        if(isGrounded && Input.GetAxis("Jump") > 0f)
        {
            verticalForce = new Vector3(0f, jumpForce, 0f);
            isGrounded = false;
        }
    }

    // Funcion provicional de gravedad
    void Gravity()
    {
        // Si no estamos tocando el suelo
        if(!isGrounded)
        {
            verticalForce += Physics.gravity * Time.deltaTime;
        }
        else
        {
            verticalForce = new Vector3(0f, -2f, 0f);
        }
        // Aplicar la fuerza vertical
        characterController.Move(verticalForce * Time.deltaTime);
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

    // Funcion para conseguir el valor de isGrounded del detector
    void CheckGround()
    {
        isGrounded = groundDetector.GetIsGrounded();
    }
}