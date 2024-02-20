using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    float offset = 30f; 
    public SpawnObtaculos spawnObtaculos;

    void Start()
    {
        if(roads!=null && roads.Count>0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
        //spawnObtaculos.InicializarObstaculos(roads);
    }

    
    public void MoveRoads()
    {
        GameObject moveRoad = roads[0];
        roads.Remove(moveRoad);
        float newZ = roads[roads.Count-1].transform.position.z + offset;
        moveRoad.transform.position = new Vector3(0,0, newZ);
        roads.Add(moveRoad);

        //spawnObtaculos.SpawnEnCarretera(moveRoad);
    }

    private void Update()
    {
        spawnObtaculos.SpawnEnCarretera();
    }
}
