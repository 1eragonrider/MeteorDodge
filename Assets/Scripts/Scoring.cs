using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text scoreText;
    public CollisionHandling collisionHandling;

    private float score;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (collisionHandling.GameOver == false)
        {
            score = Time.timeSinceLevelLoad;
            int intScore = (int)score;
            scoreText.text = "SCORE: " + intScore;
        }
    }
}
