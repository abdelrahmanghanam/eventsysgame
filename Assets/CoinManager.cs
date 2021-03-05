using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{


    public GameObject[] objectsToSpawn;
    public float distanceToSpawnFromPlayer;
    public Transform player;
    public float putEveryTime = 5.0f;
    public float TTL;
    int activeCoins = 0;
    public static bool remove;
    public int maxObstacles;


    void OnEnable()
    {
        EventManager.StartListening("CoinSpawned", CoinSpawned);
        EventManager.StartListening("CoinDisappeared", CoinDisappeared);
    }

    void OnDisable()
    {
        EventManager.StopListening("CoinSpawned", CoinSpawned);
        EventManager.StartListening("CoinDisappeared", CoinDisappeared);

    }






    public void Start()
    {
        remove = false;
        TTL = putEveryTime;
    }

    void Update()
    {
        TTL -= Time.deltaTime;
        if (TTL<0 && (maxObstacles>activeCoins))
        {
            Spawn(objectsToSpawn[0]);
            TTL = putEveryTime;
        }
        /*
        if (remove)
        {
            remove = false;
            activeCoins.RemoveAt(0);
        }
        */
        print(activeCoins);
    }

    void Spawn(GameObject spawnObject)
    {
        Vector3 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos.z += distanceToSpawnFromPlayer;
        spawnPos.y += 2;
        GameObject obji = Instantiate(spawnObject, spawnPos, Quaternion.identity);
        EventManager.TriggerEvent("CoinSpawned");
    }

    void CoinSpawned()
    {

        activeCoins += 1;
    }

    void CoinDisappeared()
    {

        activeCoins -= 1;
    }
    void ScoreAdd()
    {

    }



}
