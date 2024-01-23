using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirFueraEscena : MonoBehaviour
{
    float limite = -10;
    Transform player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        if(transform.position.z < player.position.z+limite)
        {
            Destroy(gameObject);
        }
    }
}
