using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{
    public Weapon weapon;
    public TMP_Text cartridgeText;
    public TMP_Text bulletText;
    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        cartridgeText.text = weapon.cartridges.Count.ToString() + "/" + weapon.weaponData.cartridgesAmount;
        if(weapon.cartridges.Count > 0)
            bulletText.text = weapon.cartridges[0].GetBullets.ToString() + "/" + weapon.weaponData.cartridgeBullets;
        else
            bulletText.text = "0/" + weapon.weaponData.cartridgeBullets;
    }
}
