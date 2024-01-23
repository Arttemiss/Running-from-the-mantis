using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPuntuacion : MonoBehaviour
{
    public float timer = 0;

    public TextMeshProUGUI textoTimerPro;

    public void sumarPuntos(int puntos)
    {
        
        timer += puntos;
       
    }
    private void Update()
    {
        timer -= Time.deltaTime;

        textoTimerPro.text = "" + timer.ToString("f1");

        textoTimerPro.text = "Puntos: " + timer.ToString();
       
        if (timer < 0)
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
