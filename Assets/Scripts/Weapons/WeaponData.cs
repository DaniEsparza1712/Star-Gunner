using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu (menuName ="Assets/Weapon Data")]
public class WeaponData: ScriptableObject
{
    public string weaponName;
    public int cartridgesAmount;
    public int cartridgeBullets;
    public int damage;
    public float shootingRate;
    public float scope;
    public float rechargeTime;
    public weaponType type;
    public AudioClip shootSound;
    public AudioClip reload1;
    public AudioClip reload2;
    public enum weaponType{
        rifle,
        laser,
        shotgun
    }

}
