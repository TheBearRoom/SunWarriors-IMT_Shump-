using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamgeTaking : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _rb;
    [SerializeField] int EnemyHP = 1;

   void Awake()
    {
        _transform = transform;

        _rb = GetComponent<Rigidbody2D>();

        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void takeDamage()
    {
        EnemyHP--;
        if (EnemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
