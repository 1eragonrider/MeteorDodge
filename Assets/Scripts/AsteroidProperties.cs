using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidProperties : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[4]; // array of sprites
    public float asteroidSpeed = 30f;

    private SpriteRenderer spriteR;
    private Rigidbody2D rb2d;
    private CircleCollider2D circleCollider;
    private int[] mass = new int[4] {5,10,20,40};
    private float[] radius = new float[4] {0.16f,0.32f,0.64f,1.28f};
    private string[] tags = new string[4] { "SmallAsteroid","MediumAsteroid","LargeAsteroid","UltraAsteroid"};
    private float maxLifetime = 50f;
    private int spriteIndex;


    // Start is called before the first frame update
    private void Awake()
    {
        spriteR = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }


    private void Start()
    {
        int index = Random.Range(0, sprites.Length); // index equal to a random number in sprites.length range
        spriteIndex = index;
        spriteR.sprite = sprites[index]; // random sprite from the array between 0 and number of sprites
        transform.eulerAngles = new Vector3(0f, 0.0f, Random.value * 360.0f); //Random rotation
        rb2d.mass = mass[index];
        circleCollider.radius = radius[index];
        gameObject.tag = tags[index];
    }
    
    public void SetTrajectory(Vector2 direction)
    {
        rb2d.AddForce(direction * asteroidSpeed * 3*mass[spriteIndex]);

        Destroy(gameObject, maxLifetime);
    }
}
