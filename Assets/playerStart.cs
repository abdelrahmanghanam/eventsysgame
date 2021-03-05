using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerStart : MonoBehaviour
{
    public Rigidbody rb;
    public Transform tr;
    Scene scene;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        rb.AddForce(0, 0, 10000);
        scene = SceneManager.GetSceneByName("SampleScene");
        
    }
    private void Update()
    {

        tr.Translate(Vector3.right * 2.0f * Input.GetAxis("Horizontal") * Time.deltaTime);

    }
    void OnCollisionEnter(Collision targetObj)
    {

        if (targetObj.gameObject.tag == "Obstacle")
        {
            ((playerStart)gameObject.GetComponent<playerStart>()).enabled = false;
            GameObject otherobj = GameObject.Find("Main Camera");
            (otherobj.GetComponent("cameraScript") as MonoBehaviour).enabled = false;
            Invoke("ResetGame", 1.0f);

        }

    }
    void ResetGame()
    {
        // Restarts the current level 
        SceneManager.LoadScene(scene.buildIndex);
        ScoreDetector.playerScore = 0;
    }



}
