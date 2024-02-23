using UnityEngine;

// Varje vapen måste ha ", IWeapon" på sig
public class Weapon1 : MonoBehaviour, IWeapon
{
    // Här lägger man in den kod som ska trigga vapnet. Resten av koden kan vara
    // vad som helst.
    // Men den här delen måste finnas.
    void IWeapon.Fire()
    {
       
    }
}