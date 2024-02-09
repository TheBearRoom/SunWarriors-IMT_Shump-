using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using InfinityCode.UltimateEditorEnhancer;
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
    [SerializeField] private AnimationCurve Anicurve;
    [SerializeField] private int MovMultiplier = 5;
    [SerializeField] private int drag = 6;
    private float curvePos;
    private bool positiveX = false;
    private bool NegativeX = false;
    private bool positiveY = false;
    private bool NegativeY = false;
    
    
    
    
    


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
        Vector2 direction = Vector2 .zero; 
        //Positive X
        if (_movemntSpeed.x > 0)
        {
            curvePos += Time.deltaTime; 
            direction.x = (Anicurve.Evaluate(curvePos)) * MovMultiplier;
            positiveX = true;
        }
        else
        {
            positiveX = false;
        }
        
        //Negative X
        if (_movemntSpeed.x < 0)
        {
            curvePos += Time.deltaTime; 
            direction.x = (Anicurve.Evaluate(curvePos)) * -MovMultiplier;
            NegativeX = true;
        }
        else
        {
            NegativeX = false;
        }
        
        //Positive Y
        if (_movemntSpeed.y > 0)
        {
            curvePos += Time.deltaTime; 
            direction.y = (Anicurve.Evaluate(curvePos)) * MovMultiplier;
            positiveY = true;
        }
        else
        {
            positiveY = false;
        }
        
        //Negative Y
        if (_movemntSpeed.y < 0)
        {
            curvePos += Time.deltaTime; 
            direction.y = (Anicurve.Evaluate(curvePos)) * -MovMultiplier;
            NegativeY = true;
        }
        else
        {
            NegativeY = false;
        }
        
        
        //slow down if no button pressed
        if ((positiveX == false) && (NegativeX == false) && (positiveY == false) && (NegativeY == false))
        {
            _rb.drag = drag;
            curvePos = 0;
            print(_movemntSpeed);
        }
        else
        {
            _rb.velocity = direction;
        }





        

        
    }

    void OnRotate(InputValue v)
    {
        
        //rotate ship towards mouse
        Vector3 mousePosition = v.Get <Vector2>();
        print(mousePosition);
        //Vector2.LookAt = Vector2.zero;
        if (mousePosition.x > 4)
        {
            //transform.up = Vector2.right;
            
        }
        if (mousePosition.x < -4)
        {
            //transform.up = -Vector2.right;
        }
        if (mousePosition.y > 4)
        {
            //transform.up = Vector2.up;
        }
        if (mousePosition.y < -4)
        {
            //transform.up = -Vector2.up;
       
        }

        mousePosition *= 10;
        mousePosition += transform.position;
        transform.LookAt(mousePosition, Vector3.forward);
        Vector3 rotate = transform.rotation.eulerAngles;
        rotate.x = 0;
        rotate.y = 0;
        transform.localRotation.eulerAngles = rotate;
    }



    void OnMove(InputValue v)
    {
        _movemntSpeed = v.Get<Vector2>();
    }
}
