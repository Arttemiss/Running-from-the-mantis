using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovimientoJugador : MonoBehaviour
{
    public GameObject imagen;
    public List<Sprite> iconos;
    
    float horizontalMove;
    public CharacterController player;

    
    public float playerSpeed;
    public float gravity;
    private Animator animator;

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
    Image otracosa;

    private void Start()
    {
        player = GetComponent<CharacterController>();
        animator = transform.GetChild(2).GetComponent<Animator>();
        otracosa = imagen.GetComponent<Image>();
        

    }

    private void Update()
    {
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        Cambioicono();
        if (Input.GetKeyDown(KeyCode.A)&& !muerte)
        {
            animator.SetBool("Deslizar_izq", true);
            moverIzquierda();

        }
        else if (Input.GetKeyDown(KeyCode.D)&& !muerte)
        {
            moverDerecha();
            animator.SetBool("Deslizar_derech", true);
         
        }
        else
        {
            animator.SetBool("Deslizar_derech", false);
            animator.SetBool("Deslizar_izq", true);
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
            //animator.SetBool("Deslizarse_izq", true);
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
        transform.position = new Vector3(carriles[carrilActual].position.x, transform.position.y+0.2f, transform.position.z);
        player.enabled = true;
    }



    public void PlayerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump") && botas)
        {
            movePlayer.y = Mathf.Sqrt(7 * jumpForce * gravity);
            botas = false;
            animator.SetBool("Saltar", true);
            Invoke("TocaHierba", 2f);

        }
        else if (player.isGrounded && Input.GetButtonDown("Jump") && !botas)
        {
            movePlayer.y = Mathf.Sqrt(2 * jumpForce * gravity);
            animator.SetBool("Saltar", true);
            Invoke("TocaHierba", 2f);


        }
        if (player.isGrounded && Input.GetButtonDown("Vertical"))
        {
            animator.SetBool("Deslizarse", true);
            //Invoke("noagachada", 0.5f);
        }

    }

    public void TocaHierba()
    {
        animator.SetBool("Saltar", false);
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
            if (!botas && !iman && !gafas) //|| !otro)
            {
                pico = true;

            }
            Destroy(other.gameObject);
        }

        if (other.CompareTag("iman"))
        {
            if (!pico && !botas && !gafas)
            {
                iman = true;
                Invoke("Fueraiman", 4);
            }
            Destroy(other.gameObject);
        }

        if (other.CompareTag("gafas"))
        {
            if (!pico && !botas && !iman)
            {
                gafas = true;
            }
            Destroy(other.gameObject);
        }

        //intento doble salto
        if (other.CompareTag("botas"))
        {
            if(!pico && !iman && !gafas)
            {
                botas = true;
                
            }
            Destroy(other.gameObject);
            
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
    public void Fueraiman()
    {
        iman = false;
    }
    public void Cambioicono()
    {
        if (botas)
        {
            otracosa.sprite = iconos[0];
        }
        else if (iman)
        {
            otracosa.sprite = iconos[1];
        }
        else if (pico)
        {
            otracosa.sprite = iconos[2];
        }
        else if (gafas)
        {
            otracosa.sprite = iconos[3];
        }
        else
        {
            otracosa.sprite = null;
        }
    }
    
}
