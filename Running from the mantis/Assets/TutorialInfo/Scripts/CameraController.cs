using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;

    float yoffset = 10;
    float zoffset = -24;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void LateUpdate()
    {
        transform.position = new Vector3(0, player.position.y + yoffset, player.position.z + zoffset);
    }
}
