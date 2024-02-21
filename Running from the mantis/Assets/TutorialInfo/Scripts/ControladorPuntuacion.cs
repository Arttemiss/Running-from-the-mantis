using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPuntuacion : MonoBehaviour
{
    public float timer = 20;

    public TextMeshProUGUI textoTimerPro;
    float minutos = 0;
    float segundos = 0;

    public void sumarPuntos(int puntos)
    {
        timer += puntos;
       
    }
    private void Update()
    {
        //Debug.Log("timer "+timer);

        timer -= Time.deltaTime;
        minutos = Mathf.Floor(timer/60);
        segundos = timer % 60;

        textoTimerPro.text = minutos.ToString() + ":" + Mathf.RoundToInt(segundos).ToString();

        
       
        if (timer <= 0)
        {
            Debug.Log("Game Over");
            levelManager.LM.GameOver();
        }

    }

    public void getPuntos()
    {
        print(timer);
        //return puntaje;
    }



}
