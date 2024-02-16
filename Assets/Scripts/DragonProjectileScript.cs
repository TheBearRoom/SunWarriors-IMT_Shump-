using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonProjectileScript : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public float force;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        
        Vector3 direction = player.transform.position - transform.position; 
        //This determines the direction in which the bullet will go (towards the player's position when it was shot).
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    void Update()
    {
        
    }
}
