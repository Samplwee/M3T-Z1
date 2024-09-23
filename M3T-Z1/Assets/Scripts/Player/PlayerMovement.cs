using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{

    public CharacterController characterController; 
    public float speed =10f;
    public float gravity =-9.8f;

    public Transform groundCheck;
    public float sphereRadius =0.3f ;
    public LayerMask groundMask;
    bool isGrounded;

    public float jumpHeigth = 3;
    //Altura del salto

    public bool isSprinting;
    //Esta corriendo?

    public float sprintingSpeedMultipler = 1.5f;//Factor multiplicativo al correr

    private float sprintingSpeed = 1;//velocidad cuando no corramos

    public float staminaUseAmount = 5; // que tanto usamos de la estamina

    private StaminaBar staminaSlider;


    private void Start()
    {
        staminaSlider = FindObjectOfType<StaminaBar>();
    }

    Vector3 velocity;

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position,sphereRadius,groundMask);
        if (isGrounded && velocity.y<0)
        {
            velocity.y=-2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move= transform.right *x + transform.forward*z;



        JumpCheck();
        RunCheck();

        characterController.Move(move *speed * Time.deltaTime*sprintingSpeed);
        //Multiplicamos la velocidad por el sprint si no estamos corriendo este se queda en 1 y todo por 1 es igual, a no ser que estemos corriendo, que pasa a ser 1.5 multiplicado por todo lo anterior


        velocity.y += gravity* Time.deltaTime;
        characterController.Move(velocity*Time.deltaTime );
    }

    public void JumpCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeigth * -2 * gravity);
        }
    }

    public void RunCheck()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = !isSprinting;
            //interruptor pasa saber si esta corriendo
            if (isSprinting == true)
            { 
                staminaSlider.UseStamina(staminaUseAmount);
            }
            else
            {
                staminaSlider.UseStamina(0);    
            }
        }

        if (isSprinting == true)
        {
            sprintingSpeed = sprintingSpeedMultipler;
            //Si estamos presionando shift osea isSprinting es true nuestro multiplicador de velocidad pasa a ser 1.5
            staminaSlider.UseStamina(staminaUseAmount);
        }
        else
        {
            sprintingSpeed = 1;
            //Sino sigue siendo 1
        }


    }
}
