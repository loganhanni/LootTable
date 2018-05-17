using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public enum WeaponType {
        Sword, Wand
    };

    public WeaponType weaponType;
    public Texture weaponLogo = null;
    public float dmg = 0;
}
