using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            LifeSystem playerLife = other.GetComponent<LifeSystem>();
            playerLife.life = 0;

            Disappear playerDisappear = other.GetComponentInChildren<Disappear>();
            playerDisappear.dissolve = true;
        }
    }
}
