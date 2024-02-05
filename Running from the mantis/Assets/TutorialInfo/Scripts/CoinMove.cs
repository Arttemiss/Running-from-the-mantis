using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    Coins coinsScript;
    // Start is called before the first frame update
    void Start()
    {
        coinsScript = gameObject.GetComponent<Coins>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, coinsScript.playerTransform.position, coinsScript.moveSpeed *  Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("burbuja"))
        {
            Destroy(gameObject);
        }
    }
}
