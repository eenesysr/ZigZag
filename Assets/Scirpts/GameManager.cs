using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject lastPlane;
    public GameObject coin;
    private int timeSize = 0;
    private int timeDiff = 2;

    void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            SpawnPlane();
            SpawnCoin();
        }
    }


    void Update()
    {
        if (Time.time >= timeSize)
        {
            for(int i = 0;i < 10; i++)
            {
                SpawnPlane();
                SpawnCoin();
            }
            timeSize += timeDiff;
        }
    }
   
    private void SpawnPlane()
    {
        Vector3 vector;
        if (Random.Range(0, 2) == 0)
            vector = Vector3.left;
        else
            vector = Vector3.forward;
        lastPlane = Instantiate(lastPlane,lastPlane.transform.position + vector, lastPlane.transform.rotation);
    }

    private void SpawnCoin()
    {
        if (Random.Range(0,10) == 0)
        {
            Instantiate(coin, lastPlane.transform.position + new Vector3(0, 1.2f, 0), coin.transform.rotation);
        }
    }
}
