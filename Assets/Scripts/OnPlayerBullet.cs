using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerBullet : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _rb;
    private static int enemyHitCounter = 0;
    

    void Awake()
    {
        _transform = transform;

        _rb = GetComponent<Rigidbody2D>();

        
    }

    void Start()
    {
        Invoke("DestroyObject", 4f);
    }

    void Update()
    {

    }
    
    void DestroyObject()
    {
        Destroy(gameObject);
    }

    void TestFunction()
    {
        enemyHitCounter++;
        Debug.Log("Bullet hit an enemy: " + enemyHitCounter);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("enemy"))
        {
            collision.gameObject.GetComponent<EnemyDamgeTaking>().takeDamage();
            Destroy(gameObject);
        }
    }
}
