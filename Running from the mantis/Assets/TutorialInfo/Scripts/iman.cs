using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iman : MonoBehaviour
{
    public float forceFactor = 200f;

    List<Rigidbody> rgbCoins = new List<Rigidbody>();

    Transform magnetPoint;

    private void Start()
    {
        magnetPoint = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        foreach (Rigidbody rb in rgbCoins)
        {
            rb.AddForce((magnetPoint.position - rb.position) * forceFactor * Time.fixedDeltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))rgbCoins.Add(other.GetComponent<Rigidbody>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Coin"))rgbCoins.Remove(other.GetComponent<Rigidbody>());
    }
}
