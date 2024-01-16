using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 20 * Time.deltaTime, 0);//cambiar al eje que se necesite
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            ControladorPuntuacion controladorPuntaje = collision.GetComponent<ControladorPuntuacion>();
            controladorPuntaje.restarPuntos(100);
            controladorPuntaje.getPuntos();
        }
        
    }
}
