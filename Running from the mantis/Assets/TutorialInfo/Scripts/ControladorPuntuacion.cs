using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPuntuacion : MonoBehaviour
{
    public int puntaje = 0;
    public TextMeshProUGUI textoPuntos;


    public void sumarPuntos(int puntos)
    {
        puntaje += puntos;
        

    }
    private void Update()
    {
        textoPuntos.text = "Puntos: " + puntaje.ToString();
       

    }

    public void getPuntos()
    {
        print(puntaje);
        //return puntaje;
    }
}
