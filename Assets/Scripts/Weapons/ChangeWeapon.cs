using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public UpdateText updateText;
    private void Awake() {
        GameObject weapon;
        string weaponName = PlayerPrefs.GetString("Weapon", "Rifle");
        switch(weaponName){
            case "Rifle":
                weapon = transform.Find("Rifle").gameObject;
                weapon.SetActive(true);
                transform.Find("Shotgun").gameObject.SetActive(false);
                transform.Find("Minigun").gameObject.SetActive(false);
                break;
            case "Shotgun":
                weapon = transform.Find("Shotgun").gameObject;
                transform.Find("Rifle").gameObject.SetActive(false);
                transform.Find("Shotgun").gameObject.SetActive(true);
                transform.Find("Minigun").gameObject.SetActive(false);
                break;
            case "Minigun":
                weapon = transform.Find("Minigun").gameObject;
                transform.Find("Rifle").gameObject.SetActive(false);
                transform.Find("Shotgun").gameObject.SetActive(false);
                transform.Find("Minigun").gameObject.SetActive(true);
                break;
        }
    }
}
