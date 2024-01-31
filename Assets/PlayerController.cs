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
    [SerializeField] private float top_speed = 5;
    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private float deacceleration = 0.1f;
    
    


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
        //The following code is responsible for check if the movement keys get pressed and calculating and adding movement speed
        if (!Mathf.Approximately(_rb.velocity.x, top_speed) &&! Mathf.Approximately(_movemntSpeed.x, 0)) //If velocity In X-axis =/= Topspeed, && If button is not un-pressed
        {
            _rb.AddForce(Vector2.right * (acceleration * Mathf.Sign(_movemntSpeed.x)));
        }
        if (Mathf.Approximately(_movemntSpeed.magnitude, 0))
        {
            Debug.Log("penus1");
            _rb.drag = 100;
        }
        else
        {
            _rb.drag = 0;
        }
    }
    void OnMove(InputValue v)
    {
        _movemntSpeed = v.Get<Vector2>();
    }
}
