using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingCoins : MonoBehaviour
{
    public int coins;

    public void OnTriggerEnter(Collider Col)
    {
       if(Col.gameObject.tag == "Coin")
        {
            //Debug.Log("Ole, ole y ole!");
            coins = coins + 1;
            Col.gameObject.SetActive(false);
            Destroy(Col.gameObject) ;
        }
    }

}
