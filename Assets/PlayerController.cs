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
    [SerializeField] private AnimationCurve Anicurve;
    private float curvePos = 0;
    
    
    


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
        if (_movemntSpeed.x > 0)
        {
            curvePos += Time.deltaTime; 
        }
        else
        {
            curvePos -= Time.deltaTime;
        }
        _rb.velocity = new Vector2(Anicurve.Evaluate(curvePos), 0) * top_speed;








        /*
        //The following code is responsible for check if the movement keys is pressed and adding movement speed
        if (Mathf.Abs(_rb.velocity.x) < top_speed &&! Mathf.Approximately(_movemntSpeed.x, 0)) //If velocity In X-axis =/= Topspeed, && If button is not un-pressed
        { 
            _rb.AddForce(Vector2.right * (Anicurve.Evaluate(.5f) * Mathf.Sign(_movemntSpeed.x)));
        }

        //adds drag when not moving
        //This is bad, does not work if a WASD key is pressed before another one is realesed
       /* if (Mathf.Approximately(_movemntSpeed.magnitude, 0)) //If any movement key is not pressed
        {
            _rb.drag = 10;
        }
        else
        {
            _rb.drag = 0;
        } */
    }
    
    void OnMove(InputValue v)
    {
        //TODO: Check if vector 2 suddenly flips from negative to posetive or vice versa,
        //this means that someone is trying to switch direction by suddenly pressing the oppisate key in a WASD config, whilst having velocity speed in the other way 
        //If true add a short burst of liniar drag to help the player quickly change direction of movement. 
        _movemntSpeed = v.Get<Vector2>();
    }
}
