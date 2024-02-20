using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnObtaculos : MonoBehaviour
{
    private int SpawnAmount = 4;
    public int ratioSpawn = 2;
    public int Separacion = 10;
    public float ZInicial = 0;

    public List<GameObject> obstacles;
    
    public void InicializarObstaculos(List<GameObject> roads)
    {
        foreach (var road in roads)
        {
            SpawnEnCarretera();
        }
    }
    public void SpawnEnCarretera()
    {
        //float roadZ = road.transform.position.z;
        ZInicial += Separacion;
        for (int i = 0; i < SpawnAmount; i++)
        {
            if (Random.Range(0, ratioSpawn)== 0)
            {
                GameObject obstacle = obstacles[Random.Range(0, obstacles.Count)];
                //float ramdomX = Random.Range(-9f, 9f);
                //float ramdomZ = Random.Range(-5f, 5f);
                Instantiate(obstacle, new Vector3(0, 0, ZInicial) , obstacle .transform.rotation);
               
            }
            
        }
    }
    

}
