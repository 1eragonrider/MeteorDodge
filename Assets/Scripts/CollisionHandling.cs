using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandling : MonoBehaviour
{
    public GameObject explosion;
    public int playerHealth = 10;
    public int smallAsteroidDamage = 2;
    public int MediumAsteroidDamage = 5;
    public bool GameOver = false;

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteR;
    private CircleCollider2D circleCollider;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // player health 
        if(collision.gameObject.tag == "SmallAsteroid")
        {
            playerHealth -= smallAsteroidDamage;
        }
        else if (collision.gameObject.tag == "MediumAsteroid")
        {
            playerHealth -= MediumAsteroidDamage;
        } 
        else if (collision.gameObject.tag == "LargeAsteroid" || collision.gameObject.tag == "UltraAsteroid")
        {
            playerHealth = 0;
        }

        // player properties
        if (playerHealth <= 0)
        {
            rb2d.velocity = Vector3.zero;
            rb2d.angularVelocity = 0;
            Instantiate(explosion, position, transform.rotation = Quaternion.identity);
            spriteR.enabled = false;
            rb2d.isKinematic = true;
            circleCollider.enabled = false;
            GameOver = true;
        }
    }
}
