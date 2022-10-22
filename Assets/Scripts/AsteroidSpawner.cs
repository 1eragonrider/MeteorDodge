using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public AsteroidProperties asteroidPrefab;
    public float spawnTime = 1.0f;
    public float spawnRate = 3.0f;
    
    private float spawnDistance = 15.0f;
    private float trajectoryVariance = 20f;


    // Start is called before the first frame update
    private void Start()
    {
        transform.position = Vector3.zero;
        InvokeRepeating(nameof(Spawn), spawnTime, spawnRate);
    }


    private void Spawn()
    {
        for (int i = 0; i < 1; i++)
        {
            // random spawn point
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            // ranmdom rotation
            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            AsteroidProperties asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }
}
