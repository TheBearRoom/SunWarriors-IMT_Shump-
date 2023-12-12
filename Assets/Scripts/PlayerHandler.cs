using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandler : MonoBehaviour
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

    void OnFire()
    {
        print("Fire");
    }

    void OnMove(InputValue v)
    {
        var direction = v.Get<Vector2>();

        print($"Move: {direction}");
    }
}
