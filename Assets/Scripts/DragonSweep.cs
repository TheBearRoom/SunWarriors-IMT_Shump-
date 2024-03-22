using System.Collections;
using System.Collections.Generic;
using Febucci.UI.Actions;
using UnityEngine;

public class DragonSweep : MonoBehaviour
{
    public GameObject obj;
    public float speed = 1;

    void Start()
    {
        GetComponent<DragonSweep>().enabled = false;
    }

    void Update()
    {
        obj.transform.position = Vector3.Lerp(obj.transform.position, new Vector3(0f, 0.5f, 0f), Time.deltaTime * speed);
    }
}
