using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonShoot : MonoBehaviour
{

    public GameObject projectile;
    public Transform projectilePos;

    private float timer;
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(projectile, projectilePos.position, Quaternion.identity); 
    }
}
