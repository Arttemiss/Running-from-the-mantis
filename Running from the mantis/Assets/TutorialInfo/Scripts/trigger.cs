using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            levelManager.LM.GameOver();
        }
    }
}
