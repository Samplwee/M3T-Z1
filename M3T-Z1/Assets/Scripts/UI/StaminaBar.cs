using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaSlider;

    public float maxStamina = 100;

    private float currentStamina;

    private float regenerateStaminaTime = 0.1f;
    //Cada cuanto tiempo desde que dejamos de correr nos renegeramos

    private float regenerateAmount = 2;
    //Cantidad que nos regeneramos

    public float losingStaminaTime = 1f;

    private Coroutine myCoroutineLosing;

    private Coroutine myCoroutineRegenerate;
    //Verificadores para que solo una corutina se este usando a la vez
    
    //Tiempo que toma regenerar estamina

    void Start()
    {
        currentStamina = maxStamina;
        //Tenemos el 100 al empezar
        staminaSlider.maxValue = maxStamina;
        //Ponemos el valor maximo de la barra
        staminaSlider.value = maxStamina;
        //ponemos la barra al 100
    }
            
    public void UseStamina(float amount)
    {
        if (currentStamina-amount > 0)
        {
            if (myCoroutineLosing != null) //Esta la corutina activa?
            { 
                StopCoroutine(myCoroutineLosing);
            }

            StartCoroutine(LosingStaminaCoroutine(amount));

            if (myCoroutineRegenerate != null) //Esta la corutina activa?
            { 
                StopCoroutine(myCoroutineRegenerate);
            }

            StartCoroutine(RegenerateStamineCoroutine());
        }
        else
        {
            Debug.Log("No tienes energia");
        }
    }
    //Se crean las corutinas Permiten ejecutar operaciones que toman tiempo (como esperar unos segundos o mover objetos gradualmente) sin detener el resto del juego.
    private IEnumerator LosingStaminaCoroutine(float amount)
    {
        while (currentStamina >= 0) 
        {
            currentStamina -= amount;//el slider va a ser: el valor menos el de la perdida
            staminaSlider.value = currentStamina; //Actualizamos el slider

            yield return new WaitForSeconds(losingStaminaTime);//Vamos a perder stamina cada losingStaminaTime, es independiente a los frames por segundo
        }

        myCoroutineLosing = null;

        FindObjectOfType<Playermovement>().isSprinting = false;//Cuando la estamina sea menor a 0 vamos al Playermovement y el sprint lo rreseteamos a falso para no correr

    }

    private IEnumerator RegenerateStamineCoroutine() 
    { 
        yield return new WaitForSeconds(1);

        while (currentStamina < maxStamina)//Solo regeneramos stamina cuando esta por debajo del 100
        {
            currentStamina += regenerateAmount;//Cuanto regeneramos
            staminaSlider.value = currentStamina;

            yield return new WaitForSeconds(regenerateStaminaTime);
        }

        myCoroutineRegenerate = null;
    }



}
