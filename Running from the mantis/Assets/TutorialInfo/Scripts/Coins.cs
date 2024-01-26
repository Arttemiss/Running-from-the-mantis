using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coins : MonoBehaviour
{
    ControladorPuntuacion gameManagement;

    private void Start()
    {
        gameManagement = GameObject.FindGameObjectWithTag("GameController").GetComponent<ControladorPuntuacion>();
    }
    private void Update()
    {
        transform.Rotate(0, 0, 20 * Time.deltaTime);//cambiar al eje que se necesite
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            gameManagement.sumarPuntos(20);
            gameManagement.getPuntos();
        }
        
    }
}
