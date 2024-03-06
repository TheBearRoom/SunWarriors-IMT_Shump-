using System;
using UnityEngine;

// Varje vapen måste ha ", IWeapon" på sig
public class Weapon1 : MonoBehaviour, IWeapon
{
    
    public GameObject PlayerBullet;
    public float bulletSpeed = 10f;
    public static bool time_to_fire = true;
    [SerializeField] private bool odd_or_even = false;
    private bool fired = false;
    
    // Här lägger man in den kod som ska trigga vapnet. Resten av koden kan vara
    // vad som helst.
    // Men den här delen måste finnas.
    void IWeapon.Fire()
    {
        if (odd_or_even ==  time_to_fire)
        {
            GameObject bullet = Instantiate(PlayerBullet, transform.position, transform.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = transform.right * bulletSpeed;
            fired = true;
        }
    }

    private void Update()
    {
        if (fired == true)
        {
            fired = false;
            time_to_fire = !time_to_fire;
        }
    }
}