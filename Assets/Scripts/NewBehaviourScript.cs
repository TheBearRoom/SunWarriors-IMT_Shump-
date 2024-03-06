using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _rb;

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
}
