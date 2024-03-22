using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonShoot : MonoBehaviour
{
    // For the dragon shooting mechanics 
    public GameObject projectile;
    public Transform projectilePos;
    
    private float timer;
    public int randomNumber;

    //For rotating dragon head towards player
    public GameObject rotateTowards;
    public float speed;
    public float rotationModifier;
    
    
 
    void Start()
    {
        
    }

    void Update()
    {
        //Shooting
        timer += Time.deltaTime;
        if (timer > 1)
        { 
            for (int i = 0; i < 5;)
            {
                if (i == 2 || i == 3 || i == 4)
                {
                    shoot();
                }

                if (i == 5)
                {
                    i = 0;
                    randomNumber = Random.Range(0, 2);
                }
                
                i++;
            }

            if (randomNumber == 1)
            {
                GetComponent<DragonShoot>().enabled = false;
                GetComponent<DragonSweep>().enabled = true;
            }
            timer = 0;
        }
       
      

    }

    private void FixedUpdate()
    {
        //Dragon head rotation towards player
        if(rotateTowards != null)
        {
            Vector3 vectorToTarget = rotateTowards.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
    }

    void shoot()
    {
        Instantiate(projectile, projectilePos.position, Quaternion.identity); 
    }
}
