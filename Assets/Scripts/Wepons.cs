using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    // Gör alla vapen till prefabs och lägg dem i den här listan
    [SerializeField] private List<GameObject> weapons=new();

    public void FireAllWeapons()
    {
        
        foreach (var weapon in weapons)
        {
            // Kollar om det vapen man just processar har IWeapon
            if (weapon.TryGetComponent<IWeapon>(out var acutalWeapon))
            {
                // Det har den då avfyrar vi det vapnet
                acutalWeapon.Fire();
            }
        }
    }
}