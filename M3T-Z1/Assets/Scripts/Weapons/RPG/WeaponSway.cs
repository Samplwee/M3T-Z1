using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    private Quaternion startRotation;
    //Rotacion Inicial del arma
    public float swayAmount = 8;
    //Que tan fuerte es la rotacion
    void Start()
    {
        startRotation = transform.localRotation;
    }

    void Update()
    {
        Sway();
    }

    private void Sway()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        //Tomamos las posiciones de la camara en el eje X e Y

        Quaternion xAngle = Quaternion.AngleAxis(mouseX * -1.25f, Vector3.up);
        //Angulo formado con la horizontal y la altura de la camara

        Quaternion yAngle = Quaternion.AngleAxis(mouseY * -1.25f, Vector3.right);
        //Angulo formado con la Vertical y la altura de la camara

        Quaternion targetRotation = startRotation * xAngle * yAngle;
        //Rotacion objetiva

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * swayAmount);
        //Toma la posicion que hay en el momento, la local rotation y la cambia a la posicion en targenRotation con un tiempo determinado en Time,deltaTime que se multiplico por la cantitad de sway
    }
}
