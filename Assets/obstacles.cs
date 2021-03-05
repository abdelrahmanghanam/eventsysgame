using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Transform playerTransform;
    public float spawnZ = 2.0f;
    private float obstacleLength = 10f;
    public float safeZone = 4.0f;
    public int amnObstaclesOnScreen = 30;
    private List<GameObject> activeObstacles;
    // Start is called before the first frame update
    private void Start()
    {
        activeObstacles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amnObstaclesOnScreen; i++)
        {
            SpawnObstacle();
        }
    }
    // Update is called once per frame
    private void Update()
    {
        if (playerTransform.position.z - safeZone -4 > (spawnZ - amnObstaclesOnScreen * obstacleLength))
        {
            SpawnObstacle();
            DeleteObstacle();
        }
    }
    private void SpawnObstacle(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(obstaclePrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        go.transform.position = go.transform.position + new Vector3(1,0.7f,0);
        spawnZ += obstacleLength;
        activeObstacles.Add(go);
    }
    private void DeleteObstacle()
    {
        Destroy(activeObstacles[0]);
        activeObstacles.RemoveAt(0);
    }
}
