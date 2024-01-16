using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;

    float yoffset = 6;
    float zoffset = -7;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y + yoffset, player.position.z + zoffset);
    }
}
