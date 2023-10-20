using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    public ItemData itemData;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            switch(itemData.itemType){
                case ItemData.ItemType.bullets:
                    other.GetComponentInChildren<Weapon>().PickUpBullets(itemData.quantity);
                    break;
                case ItemData.ItemType.points:
                    PointManager.instance.PickUpPoints(itemData.quantity);
                    break;
            }
            Destroy(gameObject);
        }
    }
}
