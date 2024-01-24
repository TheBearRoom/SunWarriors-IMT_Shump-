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
    
    Vector2 previousSpeed = Vector2.zero;
    [SerializeField] Vector2 _movemntSpeed = Vector2.zero; //Misleading name, changing this vector will give the player an initial movement force when spawning. See movement multiplier. 
    public int movement_multiplier = 10;


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
        if (!Mathf.Approximately(_movemntSpeed.magnitude, 0))
        {
            Vector2 v = _rb.velocity;
            previousSpeed = _movemntSpeed;
            v = _movemntSpeed;
            _rb.velocity = v;
        }
        else
        {
            Vector2 v = _rb.velocity;
            v = previousSpeed;
            _rb.velocity = v;
            previousSpeed *= .9f; 
        }
    }
    void OnMove(InputValue v)
    {
        print("test1");
        _movemntSpeed = v.Get<Vector2>() * movement_multiplier;
    }
}
