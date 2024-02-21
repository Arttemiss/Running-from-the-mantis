using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Iconos : MonoBehaviour
{
    public Image imagen;
    public List<Sprite> iconos;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void cambio(int indice)
    {
        switch (indice)
        {
            case 0: 
                imagen.sprite = iconos[indice];
                break;

        }
    }
}
