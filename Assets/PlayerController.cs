using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.Serialization;

public class NewBehaviourScript : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _rb;
    
    [SerializeField] float _movemntSpeed = 1;


    void Awake()
    {
        _transform = transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 v = _rb.velocity; 
        v.x = _movemntSpeed;
        if (_movemntSpeed < -.1f)
        {
            transform.right = Vector3.left;
        }
        if (_movemntSpeed > .1f)
        {
            transform.right = Vector3.right;
        }
        float animationSpeed = Mathf.Abs(_movemntSpeed);
    }
    void OnMove(InputValue v)
    {
        print("test1");
        _movemntSpeed = v.Get<Vector2>().x * 5;
    }
}
