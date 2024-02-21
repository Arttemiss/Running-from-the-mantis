using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iman : MonoBehaviour
{
    public GameObject coinDetectorObj;

    private void Start()
    {
        coinDetectorObj = GameObject.Find("CarrilesPlayer/Player/CoinMagnet");
        coinDetectorObj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Odio mi vida");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Porque!!!");
            ActivationCoin();
            Destroy(transform.GetChild(0).gameObject);
        }
    }
    private void ActivationCoin()
    {
        coinDetectorObj.SetActive(true);
        Invoke("DeactivateCoin", 4f);
    }
    private void DeactivateCoin()
    {
        coinDetectorObj.SetActive(false );
    }
}
