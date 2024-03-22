using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertebrae : MonoBehaviour
{
    public GameObject rotateTowards;
    public float speed;
    public float rotationModifier;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    private void FixedUpdate()
    {
        //Dragon's vertbraes rotation towards player
        if(rotateTowards != null)
        {
            Vector3 vectorToTarget = rotateTowards.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
    }
}
