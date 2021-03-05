using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDetector : MonoBehaviour
{
    UnityEngine.UI.Text score;
    [SerializeField] GameObject player;
    public static int playerScore=0;

    void Start()
    {
        score = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text="your score is: "+(playerScore.ToString("0"));   
    }
}
