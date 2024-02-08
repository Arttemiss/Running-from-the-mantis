using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MovimientoJugador : MonoBehaviour
{
    float horizontalMove;
    public CharacterController player;
    

    public float playerSpeed;
    public float gravity;
    
    public float jumpForce;

    private Vector3 movePlayer;
    //private Vector3 playerInput;
    public SpawnManager spawnManager;

    public Transform[] carriles;

    public int carrilActual = 1;
    bool muerte = false;
    public bool pico = false;
    public bool botas = false;
    public bool iman = false;
    public bool gafas = false;

    private void Start()
    {
        player = GetComponent<CharacterController>();

    }

    private void Update()
    {
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.A)&& !muerte)
        {
            moverIzquierda();

        }
        else if (Input.GetKeyDown(KeyCode.D)&& !muerte)
        {
            moverDerecha();
        }

        
        Vector3 inputDir = new Vector3(0, 0.0f, 2);
        Vector3 moveDir = transform.TransformDirection(inputDir);
        movePlayer = new Vector3(moveDir.x * playerSpeed, movePlayer.y, moveDir.z * playerSpeed);

        SetGravity();

        PlayerSkills();
        player.Move(movePlayer * Time.deltaTime);
        Debug.Log(player.isGrounded);
    }

    public void moverIzquierda()
    {
        if(carrilActual > 0)
        {
            carrilActual--;
            MoverJugador();
            Debug.Log("Mover Izquierda");
        }
    }

    public void moverDerecha()
    {
        if (carrilActual < carriles.Length - 1)
        {
            carrilActual++;
            MoverJugador();
            Debug.Log("Mover Derecha");
        }
    }

    public void MoverJugador()
    {
        player.enabled = false;
        transform.position = new Vector3(carriles[carrilActual].position.x, transform.position.y+0.2f, transform.position.z+1.3f);
        player.enabled = true;
    }



    public void PlayerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump") && botas)
        {
            movePlayer.y = Mathf.Sqrt(7 * jumpForce * gravity);
           botas = false;
        }
        if (player.isGrounded && Input.GetButtonDown("Jump") && !botas)
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
        if (other.CompareTag("Pico"))
        {
            if (!botas || !iman || !gafas) //|| !otro)
            {
                pico = true;

            }
            Destroy(other.gameObject);
        }

        /*if (other.CompareTag("iman"))
        {
            if (!pico || !botas || !gafas)
            {
                iman = true;
            }
            Destroy(other.gameObject);
        }*/

        if (other.CompareTag("gafas"))
        {
            if (!pico || !botas || !iman)
            {
                gafas = true;
            }
            Destroy(other.gameObject);
        }

        //intento doble salto
        if (other.CompareTag("botas"))
        {
            if(!pico || !iman || !gafas)
            {
                botas = true;
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(other.gameObject);

            }
        }

        if (other.CompareTag("Obstacle"))
        {
            if (pico)
            {
                Destroy(other.gameObject);
                pico = false;
            }
            else
            {
                muerte = true;
                Debug.Log("Game Over");
                levelManager.LM.GameOver();

            }
        }

        
    }
}
