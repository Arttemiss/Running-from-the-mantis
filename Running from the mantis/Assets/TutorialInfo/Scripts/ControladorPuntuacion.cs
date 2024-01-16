using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPuntuacion : MonoBehaviour
{
    private int puntaje = 0;
    public Text textoPuntos;


    public void restarPuntos(int puntos)
    {
        puntaje -= puntos;
        

    }
    private void Update()
    {
        textoPuntos.text = "Puntos" + textoPuntos.ToString();

    }

    public void getPuntos()
    {
        print(puntaje); //provisional
        //return puntaje;
    }
}
