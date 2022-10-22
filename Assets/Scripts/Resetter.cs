using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetter : MonoBehaviour
{
    public CollisionHandling collisionHandling;
    public float resetDelay = 1f;
    public int playerHealth = 10;


    // Update is called once per frame
    void Update()
    {
        playerHealth = collisionHandling.playerHealth;

        if (playerHealth <= 0)
        {
            Invoke("Restart", 5);
            Debug.Log("Game Over!");

        } 
        //else if (Input.GetMouseButton(0))
        //{
        //    Invoke("Restart", 0);
        //    Debug.Log("Restart key pressed");
        //}
    }
    private void Restart()
    {
        SceneManager.LoadScene("Game Scene");
    }
}
