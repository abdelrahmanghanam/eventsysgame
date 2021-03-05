using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public float TTL = 2.0f;
    public TextMeshPro text;
    public int worth = 1;
    [SerializeField] public Transform tr;




    public bool Move = true;   
    public Vector3 MoveVector = Vector3.up; 
    public float MoveRange = 1.0f; 
    public float MoveSpeed = 100.0f; 

    private CoinScript bounceObject; 

    Vector3 startPosition;



    void Start()
    {


        bounceObject = this;
        startPosition = bounceObject.transform.position;
        startPosition.y += 1.0f;


        gameObject.GetComponentInChildren<TextMeshPro>().text = "hhaahhha";
        transform.rotation = Quaternion.Euler(new Vector3(90.0f,0,0));
    }


    // Update is called once per frame
    void Update()
    {
        TTL -= Time.deltaTime;
        gameObject.GetComponentInChildren<TextMeshPro>().text = TTL.ToString("0");

        if (TTL < 0)
        {
            Die();
        }


        if (Move) //bool is checked
            bounceObject.transform.position = startPosition + MoveVector * (MoveRange * Mathf.Sin(Time.timeSinceLevelLoad * MoveSpeed));


    }
    void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            EventManager.TriggerEvent("CoinCollected");
            EventManager.TriggerEvent("gameObjectCollision");
            Die();
        }

    }

    public float getTTL()
    {
        return TTL;
    }
    public void Die()
    {
        Destroy(gameObject);
        EventManager.TriggerEvent("CoinDisappeared");

    }

    void OnEnable()
    {
        EventManager.StartListening("CoinCollected", CoinCollected);
    }

    void OnDisable()
    {
        EventManager.StartListening("CoinCollected", CoinCollected);
    }
    void CoinCollected()
    {
        ScoreDetector.playerScore= ScoreDetector.playerScore+worth;
    }
}
