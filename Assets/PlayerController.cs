using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _rb;
    
    [SerializeField] float movementSpeed = 1;


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
        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        print("PlayerInput");
    }
}
