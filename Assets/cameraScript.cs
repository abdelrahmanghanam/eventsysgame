using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Transform tr;
    void Start()
    {
        player = GameObject.Find("Player");
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = player.transform.position;
        temp.x = player.transform.position.x;
        temp.y = player.transform.position.y + 3;
        temp.z = player.transform.position.z - 5;
        tr.position = temp;

    }
}
