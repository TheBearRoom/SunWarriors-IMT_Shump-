using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using InfinityCode.UltimateEditorEnhancer;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.Mathematics;
using UnityEngine.Serialization;

public class NewBehaviourScript : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _rb;
    Vector2 previousSpeed = Vector2.zero;
    [SerializeField] private List<GameObject> weapons=new();
    [SerializeField] Vector2 _movemntSpeed = Vector2.zero; //Misleading name, changing this vector will give the player an initial movement force when spawning. See movement multiplier. 
    [SerializeField] private AnimationCurve Anicurve;
    [SerializeField] private int MovMultiplier = 5;
    [SerializeField] private int drag = 6;
    [SerializeField] float turningSpeed = 10;
    private int test_int = 0;
    private float curvePos;
    private bool positiveX = false;
    private bool NegativeX = false;
    private bool positiveY = false;
    private bool NegativeY = false;
    private float _targetAngle = 0;
    public int active_gun = 0;
    
    
    void Awake()
    {
        _transform = transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Cursor.visible = false; 
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
        }
        else
        {
            _rb.velocity = direction;
        }
        
        //updtae angel and turn smoothly, e.g anti-snap
       float newAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.z,_targetAngle, turningSpeed);
       transform.eulerAngles = new Vector3(0, 0, newAngle);
    }
    //fetch new rotation based on arrow keys
    void OnAim(InputValue v)
    {
        var test = v.Get<Vector2>();
        test.x = -test.x;
        _targetAngle = Vector2.SignedAngle(test, Vector2.up); 
    }
    void OnMove(InputValue v)
    {
        _movemntSpeed = v.Get<Vector2>();
    }

    void OnFire(InputValue v)
    {
        GetComponent<Weapons>().FireAllWeapons();
    }
}
