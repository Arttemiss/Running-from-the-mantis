using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovimientoJugador : MonoBehaviour
{
    float horizontalMove;
    public CharacterController player;
    

    public float playerSpeed;
    public float gravity;
    
    public float jumpForce;

    private Vector3 movePlayer;
    private Vector3 playerInput;
    public SpawnManager spawnManager;

    private void Start()
    {
        player = GetComponent<CharacterController>();

    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 inputDir = new Vector3(horizontal, 0.0f, 2);
        Vector3 moveDir = transform.TransformDirection(inputDir);
        movePlayer = new Vector3(moveDir.x * playerSpeed, movePlayer.y, moveDir.z * playerSpeed);

        SetGravity();

        PlayerSkills();
        player.Move(movePlayer * Time.deltaTime);
        Debug.Log(player.isGrounded);
    }

    

    public void PlayerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            movePlayer.y = Mathf.Sqrt(2 * jumpForce * gravity);
           
        }
    }

    public void SetGravity()
    {
        if  (!player.isGrounded)
        {
            movePlayer.y -=gravity * Time.deltaTime;
            
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spawn"))
        {
            spawnManager.SpawnTrigger();

        }
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            levelManager.LM.GameOver();
        }
    }
}
