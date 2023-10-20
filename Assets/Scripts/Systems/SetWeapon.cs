using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWeapon : MonoBehaviour
{
    public void ChangeWeapon(string weaponName){
        PlayerPrefs.SetString("Weapon", weaponName);
        PlayerPrefs.Save();
    }
}
