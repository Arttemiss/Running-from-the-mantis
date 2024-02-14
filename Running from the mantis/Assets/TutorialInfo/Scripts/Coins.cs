using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class Coins : MonoBehaviour
{
    ControladorPuntuacion gameManagement;
    public Transform playerTransform;
    public float moveSpeed = 17f;

    CoinMove coinMoveScript;
    private void Start()
    {
        gameManagement = GameObject.FindGameObjectWithTag("GameController").GetComponent<ControladorPuntuacion>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        coinMoveScript = gameObject.GetComponent<CoinMove>();
    }
    private void Update()
    {
        transform.Rotate(0, 0, 20 * Time.deltaTime);//cambiar al eje que se necesite
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("burbuja"))
        {
            gameManagement.sumarPuntos(5);
            gameManagement.getPuntos();
        }
        if (collision.CompareTag("Coin Detector"))
        {
            coinMoveScript.enabled = true;
        }
        
    }
}
